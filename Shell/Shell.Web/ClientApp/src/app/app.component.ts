import { AfterViewInit, Component } from '@angular/core';
import { ConfigurationService } from './shared/services/configuration.service';
import { ElementRegistryService } from './shared/services/element-registry.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit {
  title = 'app';

  constructor(
    private configService: ConfigurationService,
    private elementRegistry: ElementRegistryService) {
  }


  ngAfterViewInit(): void {
    this.configService.loadShellConfiguration(false).then(() => {
      this.elementRegistry.loadAllApps();
    });
  }

}
