import { CUSTOM_ELEMENTS_SCHEMA, Injector, NgModule } from '@angular/core';
import { NoteViewComponent } from "./note-view.component";
import { HttpClientModule } from "@angular/common/http";
import { NoteViewService } from './note-view.service';
import {CardModule} from 'primeng/card';

@NgModule( {
  declarations: [
    NoteViewComponent
  ],
  entryComponents: [ NoteViewComponent ],
  imports: [
    HttpClientModule,
    CardModule,
  ],
  providers: [
    NoteViewService
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
} )
export class NoteViewModule {
  constructor(injector: Injector ) {
  }
  ngDoBootstrap() {

  }
}

