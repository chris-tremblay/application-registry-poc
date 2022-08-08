import { Component, OnInit, ElementRef, NgZone, Input } from '@angular/core';
import { NoteViewService } from './note-view.service';

@Component({
  selector: 'app-note-view',
  templateUrl: './note-view.component.html',
  styleUrls: ['./note-view.component.scss']
})
export class NoteViewComponent implements OnInit {

  private _noteId: number = 0;
  note: any;

  constructor(
  private readonly element: ElementRef,
  private readonly zone: NgZone,
  private readonly noteViewService: NoteViewService) {

    const webComponent = this.element.nativeElement;
    Object.defineProperties(webComponent, {
      noteId: {
        get: () => this.noteId,
        set: (noteId: number) => zone.run(() => this.noteId = noteId)
      }
    });
  }

  set noteId(value: number){
    this._noteId = value;

    this.loadData();
  }
  get noteId(): number{
    return this._noteId;
  }

  ngOnInit(): void {
  }

  loadData(){
    this.noteViewService.getNoteById(this._noteId).subscribe((data)=>{
      console.log(data);
      this.note = data;
    });
  }

}
