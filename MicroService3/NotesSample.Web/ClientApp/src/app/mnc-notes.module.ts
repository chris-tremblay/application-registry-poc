import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, Injector, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MncNotesAppComponent } from './mnc-notes.component';
import { StateSelectorComponent } from './state-selector/state-selector.component';
import { createCustomElement } from '@angular/elements';
import { ComposedWidgetComponent } from './composed-widget/composed-widget.component';
import { RouterModule, Routes } from '@angular/router';
import { EmptyComponent } from './empty/empty.component';

const routes: Routes = [
  { path: '**', component: EmptyComponent }
];

@NgModule({
  declarations: [
    MncNotesAppComponent,
    StateSelectorComponent,
    ComposedWidgetComponent,
    EmptyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes, { useHash : true }),
  ],
  providers: [],
  bootstrap: [
    StateSelectorComponent, 
    ComposedWidgetComponent  
  ],
  entryComponents:[MncNotesAppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MncNotesAppModule {
  constructor(
    private injector: Injector
  ) 
  {
    customElements.define('mnc-notes', createCustomElement(MncNotesAppComponent, { injector }));
    customElements.define('mnc-notes-state-selector', createCustomElement(StateSelectorComponent, { injector }));
    customElements.define('mnc-notes-composed-widget', createCustomElement(ComposedWidgetComponent, { injector }));
  }
}