import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { IMicroApplication } from '../interfaces/microapplication.interface';
import { IElementRegistryService } from '../interfaces/element-registry.interface';
import { ConfigurationService } from './configuration.service';


@Injectable({
    providedIn: 'root'
})
export class ElementRegistryService implements IElementRegistryService {
    static loadedScripts: { [url: string]: Promise<any> } = {};
    private knownElements: any = {};

    constructor(
        private http: HttpClient,
        private config: ConfigurationService
    ) {}

    /** Ensures scripts and styles for the given custom-element are loaded. */
    prepare(name: string): Promise<IMicroApplication> {
        if (this.knownElements.hasOwnProperty(name)) {
            return this.knownElements[name];
        }

        return (this.knownElements[name] = this.http
            .get<IMicroApplication>(`${this.config.shellConfiguration.registryUrl}/elements/${name}.json`)
            .toPromise()
            .then(info => {
                if (!info) {
                    throw new Error(`The element ${name} json file was not found`);
                }
                this.addToKnownElements(info, name);
                this.loadStyles(info);
                return this.loadScripts(info).then(() => info);
            }));
    }

    public loadAllApps(): Promise<any> {
        return this.http
            .get<string[]>(`${this.config.shellConfiguration.registryUrl}/applications/element-names`)
            .toPromise()
            .then(elements => Promise.all(elements.map(i => this.prepare(i))));
    }

    baseUrlFor(applicationName: string): string {
        const script = document.querySelector('script[data-for="' + applicationName + '"]') as any;
        return (script && script.src.replace(/\/[^\/]+$/, '/')) || null;
    }

    addToKnownElements(info: any, name: string) {
        if (info.appElementName !== name) {
            this.knownElements[info.appElementName] = this.knownElements[name];
        }
        info.widgets.forEach((w: any) => {
            const widgetName = w.name || w;

            if (widgetName  !== name) {
                this.knownElements[widgetName] = this.knownElements[name];
            }
        });
    }

    private loadStyles(info: IMicroApplication) {
        if (info.styleUrls === undefined) {
            return;
        }

        info.styleUrls.forEach(url => {
            if (document.head.querySelector(`link[href="${url}"]`) == null) {
                const style = document.createElement('link');
                style.setAttribute('rel', 'stylesheet');
                style.href = url;
                document.head.appendChild(style);
            }
        });
    }

    private loadScripts(info: any) {
        const promises = info.scriptUrls.map(url => this.loadScript(url, info.appElementName));
        return Promise.all(promises).then(() => console.log('Loaded all scripts'), _ => Promise.reject(`Cannot load scripts for ${info.appElementName}`));
    }

    private loadScript(url: string, name: string): Promise<any> {
        if (ElementRegistryService.loadedScripts[url]) {
            return ElementRegistryService.loadedScripts[url];
        }

        return (ElementRegistryService.loadedScripts[url] = new Promise((resolve, reject) => {
            const script = document.createElement('script');
            script.setAttribute('data-for', name);
            script.onload = () => {
                console.log(`loaded ${url}`);
                resolve(1);
            };
            script.onerror = () => reject(`Failed to load ${url}`);
            script.src = url;
            document.body.appendChild(script);
        }));
    }
}
