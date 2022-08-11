import { Component, ElementRef, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StateSelectorService } from './state-selector.service';

@Component({
  selector: 'mnc-notes-state-selector-angular',
  templateUrl: './state-selector.component.html',
  styleUrls: ['./state-selector.component.css'],
  
})
export class StateSelectorComponent implements OnInit {

  @Input('country') country = 'United States';
  @Output('stateSelected') stateSelected = new EventEmitter<string>();

  constructor(private service: StateSelectorService, private element : ElementRef) { 
    
  }

  public states: string[];

  ngOnInit(): void {
      this.service.loadStates().then(states => this.states = states);
  }

  public selectState(event): void {
    this.stateSelected.emit(event.target.value);
    // this.element.nativeElement
    //   .dispatchEvent(new CustomEvent('onchanged', {
    //     detail: event.target.value,
    //     bubbles: true
    //   }));
  }
}
