import { Location } from '@angular/common';
import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



import { ShellConfiguration } from './shell-configuration';

@Injectable({
    providedIn: 'root'
})
export class ConfigurationService {
    private shellConfig: ShellConfiguration;
    private httpClient: HttpClient;

    constructor(handler: HttpBackend, location: Location) {
        // create our own instance of the httpclient using the httpbackend,
        // this allows us to bypass the http interceptor tokens.
        // see https://github.com/angular/angular/issues/20203#issuecomment-368680437
        this.httpClient = new HttpClient(handler);
    }

    public loadShellConfiguration(refresh?: boolean): Promise<any> {
        const url = `${location.origin}/.well-known/shell-config`;

        return this.shellConfig && !refresh
            ? new Promise(resolve => resolve(this.shellConfig))
            : this.httpClient
                .get(url)
                .toPromise()
                .then(data => {
                this.shellConfig = <ShellConfiguration>data;
            })
            .catch(reason => {
                console.log(reason);
            });
    }

    public get shellConfiguration(): ShellConfiguration {
        return this.shellConfig;
    }
}
