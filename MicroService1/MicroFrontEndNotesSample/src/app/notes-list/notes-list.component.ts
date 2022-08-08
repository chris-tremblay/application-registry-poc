import { Component, OnInit, ElementRef, Output, EventEmitter } from '@angular/core';
import { SampleDataService } from './notes-list.service';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.scss']
})
export class NotesListComponent implements OnInit {
  constructor(
    private readonly element: ElementRef,
    private sampleDataService: SampleDataService) {

    const webComponent = this.element.nativeElement;

    Object.defineProperties(webComponent, {});

  }

  sampleData: any;

  @Output() noteIdSelected: EventEmitter<number> = new EventEmitter<number>();

  ngOnInit(): void {
    this.sampleDataService.getSampleList().subscribe((data)=>{
      console.log(data);
      this.sampleData = data;
    });
  }

  handleViewNote(id: number){
    this.noteIdSelected.emit(id);
  }
}
