import { CUSTOM_ELEMENTS_SCHEMA, Injector, NgModule } from '@angular/core';
import { NotesListComponent } from "./notes-list.component";
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { ButtonModule } from 'primeng/button';
import {TableModule} from 'primeng/table';
import { SampleDataService } from './notes-list.service';

@NgModule( {
  declarations: [
    NotesListComponent
  ],
  entryComponents: [ NotesListComponent ],
  imports: [
    BrowserModule,
    HttpClientModule,
    TableModule,
    ButtonModule
  ],
  providers: [
    SampleDataService
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
} )
export class NotesListModule {
  constructor(injector: Injector ) {
  }
  ngDoBootstrap() {

  }
}

