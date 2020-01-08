import { TestBed, inject } from '@angular/core/testing';

import { Mswan3cPeopleService } from './mswan3c-people-service.service';

describe('Mswan3cPeopleServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Mswan3cPeopleService]
    });
  });

  it('should be created', inject([Mswan3cPeopleService], (service: Mswan3cPeopleService) => {
    expect(service).toBeTruthy();
  }));
});
