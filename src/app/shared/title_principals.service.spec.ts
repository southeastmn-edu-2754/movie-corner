import { TestBed } from '@angular/core/testing';

import { title_principalsService } from './title_principals.service';

describe('UsersService', () => {
  let service: title_principalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(title_principalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
