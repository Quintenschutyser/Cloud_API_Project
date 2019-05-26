import { TestBed, inject } from '@angular/core/testing';

import { CountryAPiService } from './country-api.service';

describe('CountryAPiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CountryAPiService]
    });
  });

  it('should be created', inject([CountryAPiService], (service: CountryAPiService) => {
    expect(service).toBeTruthy();
  }));
});
