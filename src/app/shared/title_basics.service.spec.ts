import { TestBed } from '@angular/core/testing';

import { titlebasicsService } from './titlebasics.service';

describe('UsersService', () => {
  let service: titlebasicsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(titlebasicsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
