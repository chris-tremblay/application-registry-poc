import { TestBed } from '@angular/core/testing';

import { SampleDataService } from './notes-list.service';

describe('SampleDataService', () => {
  let service: SampleDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SampleDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
