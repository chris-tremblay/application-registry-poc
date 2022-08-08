import { Component, OnInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-note-wrapper',
  templateUrl: './note-wrapper.component.html',
  styleUrls: ['./note-wrapper.component.scss']
})
export class NoteWrapperComponent implements OnInit {

  constructor(private readonly element: ElementRef) {

    const webComponent = this.element.nativeElement;
    Object.defineProperties(webComponent, {});
  }

  noteId: number = 0;

  ngOnInit(): void {
  }

  handleSelectNote(event: any){
    this.noteId = event.detail;
  }

}
