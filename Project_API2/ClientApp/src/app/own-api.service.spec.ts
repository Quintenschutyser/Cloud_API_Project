import { TestBed, inject } from '@angular/core/testing';

import { OwnApiService } from './own-api.service';

describe('OwnApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OwnApiService]
    });
  });

  it('should be created', inject([OwnApiService], (service: OwnApiService) => {
    expect(service).toBeTruthy();
  }));
});
