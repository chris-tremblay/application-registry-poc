import { TestBed } from '@angular/core/testing';

import { StateSelectorService } from './state-selector.service';

describe('StateSelectorService', () => {
  let service: StateSelectorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StateSelectorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
