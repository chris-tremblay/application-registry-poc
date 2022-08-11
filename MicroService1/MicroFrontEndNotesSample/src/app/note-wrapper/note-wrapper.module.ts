import { CUSTOM_ELEMENTS_SCHEMA, Injector, NgModule } from '@angular/core';
import { NoteWrapperComponent } from "./note-wrapper.component";
import { BrowserModule } from '@angular/platform-browser';

@NgModule( {
  declarations: [
    NoteWrapperComponent
  ],
  entryComponents: [ NoteWrapperComponent ],
  imports: [
    BrowserModule
  ],
  providers: [
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
} )
export class NoteWrapperModule {
  constructor(injector: Injector ) {
  }
  ngDoBootstrap() {

  }
}

