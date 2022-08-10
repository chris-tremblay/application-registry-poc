import { Component, OnInit } from '@angular/core';
import { ElementRegistryService } from '../shared/services/element-registry.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(
    private elementRegistry: ElementRegistryService){
  }

  ngOnInit(): void {
    
  }

  stateSelected(e){
    console.log(e);
  }
}
