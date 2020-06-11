import { TestBed } from '@angular/core/testing';

import { namebasicsService } from './namebasics.service';

describe('namebasicsService', () => {
  let service: namebasicsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(namebasicsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
