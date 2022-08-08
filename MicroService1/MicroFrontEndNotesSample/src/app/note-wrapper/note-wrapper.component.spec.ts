import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteWrapperComponent } from './note-wrapper.component';

describe('NoteWrapperComponent', () => {
  let component: NoteWrapperComponent;
  let fixture: ComponentFixture<NoteWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteWrapperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NoteWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
