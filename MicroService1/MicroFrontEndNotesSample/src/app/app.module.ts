import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { NotesListComponent } from './notes-list/notes-list.component';
import  { Injector} from '@angular/core';
import  { createCustomElement } from '@angular/elements';
import { NotesListModule } from './notes-list/notes-list.module';
import { AppComponent } from './app.component';
import { NoteViewComponent } from './note-view/note-view.component';
import { NoteWrapperComponent } from './note-wrapper/note-wrapper.component';

@NgModule({
  declarations: [
    AppComponent,
    NoteViewComponent,
    NoteWrapperComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NotesListModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [],
  entryComponents: [AppComponent, NotesListComponent]
})
export class AppModule {
  constructor(private injector: Injector) {
    customElements.define('notelist-widget', createCustomElement(NotesListComponent, { injector }));
    customElements.define('noteview-widget', createCustomElement(NoteViewComponent, { injector }));
    customElements.define('notewrapper-widget', createCustomElement(NoteWrapperComponent, { injector }));
  }

  ngDoBootstrap(){}
 }
