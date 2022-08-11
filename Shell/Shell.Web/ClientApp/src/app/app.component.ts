import { AfterViewInit, ApplicationRef, Component, ElementRef, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { ConfigurationService } from './shared/services/configuration.service';
import { ElementRegistryService } from './shared/services/element-registry.service';

const internalRoutes = ['unauthorized', 'home', 'help'];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit {
  title = 'app';
  appId = '';

  @ViewChild('content', { static: true })
  content: ElementRef;

  constructor(
    private configService: ConfigurationService,
    private elementRegistry: ElementRegistryService,
    private cd: ApplicationRef,
    private locationService: Location) {

      this.locationService.subscribe(x => {
          this.updateHash();
      });
  }

  get isCustomRoute(): boolean {
    return internalRoutes.indexOf(this.appId) < 0;
  }

  ngAfterViewInit(): void {
    this.configService.loadShellConfiguration(false).then(() => {
      this.elementRegistry.loadAllApps().then(() => {
        const parts = location.hash.split('/');
        const appId = parts.length > 1 ? parts[1].toLowerCase() : '';

        if (!appId) {
          this.updateHash(this.configService.shellConfiguration.defaultRoute);
        } else {
          this.updateHash();
        }
      });
    });
  }

  private cleanupMicroApp() {
    const content: HTMLElement = this.content.nativeElement;

    while (content.firstChild) {
      content.removeChild(content.firstChild);
    }
  }
  updateHash(route?: string) {
    const parts = (route || location.hash).split('/');
    this.appId = parts.length > 1 ? parts[1].toLowerCase() : '';

    this.configService.loadShellConfiguration(false).then(() => {

      // this must be a custom element if it is not an internal route
      const isCustomElement = this.appId && internalRoutes.indexOf(this.appId) < 0;
      const content: HTMLElement = this.content.nativeElement;

      if (isCustomElement) {
        this.appId = this.appId && this.appId.substr(0, 4).toLowerCase() !== 'mnc-'
          ? `mnc-${this.appId}`
          : this.appId;

        this.elementRegistry.prepare(this.appId).then(_ => {
          if (content.querySelector(this.appId) == null) {
            this.cleanupMicroApp();
            this.initializeMicroApp();
          }
        });
      } else {
        this.cleanupMicroApp();
      }
      this.cd.tick();
    });
  }

  private initializeMicroApp() {
    const content: HTMLElement = this.content.nativeElement;

    const elem: HTMLElement = document.createElement(this.appId);
    
    content.appendChild(elem);
  }
}
