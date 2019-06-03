import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OwnApiService {

  constructor(private _http: HttpClient) { }

  //getInfo(defaultCountry: string = "Belgium"): Observable<RootObject> {
  //  return this._http.get<RootObject>("https://restcountries.eu/rest/v2/name/" + defaultCountry)
  //}
  //getSpecifiek(alhpaCode: string): Observable<RootObject> {
  //  return this._http.get<RootObject>("https://restcountries.eu/rest/v2/alpha/" + alhpaCode)
  //}

  //info: RootObject;
}
