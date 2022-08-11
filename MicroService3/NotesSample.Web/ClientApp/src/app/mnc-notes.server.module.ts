import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { MncNotesAppComponent } from './mnc-notes.component';
import { MncNotesAppModule } from './mnc-notes.module';

@NgModule({
    imports: [MncNotesAppModule, ServerModule, ModuleMapLoaderModule],
    bootstrap: [MncNotesAppComponent]
})
export class AppServerModule { }
