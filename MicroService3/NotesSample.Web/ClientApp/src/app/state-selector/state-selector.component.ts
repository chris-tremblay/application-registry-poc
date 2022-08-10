import { Component, ElementRef, EventEmitter, OnInit, Output } from '@angular/core';
import { StateSelectorService } from './state-selector.service';

@Component({
  selector: 'mnc-notes-state-selector',
  templateUrl: './state-selector.component.html',
  styleUrls: ['./state-selector.component.css'],
  
})
export class StateSelectorComponent implements OnInit {

  constructor(private service: StateSelectorService, private element : ElementRef) { 

    
  }

  public states: string[];

  ngOnInit(): void {
      this.service.loadStates().then(states => this.states = states);
  }

  public selectState(event): void {
    this.element.nativeElement
      .dispatchEvent(new CustomEvent('onchanged', {
        detail: event.target.value,
        bubbles: true
      }));
  }
}
