import { TestBed } from '@angular/core/testing';

import { NoteViewService } from './note-view.service';

describe('NoteViewService', () => {
  let service: NoteViewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NoteViewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
