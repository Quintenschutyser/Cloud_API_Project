import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoinApiService {

  constructor(private _http: HttpClient) { }

  baseCoin: string = "EUR";

  getInfo(base : string, convert : string): Observable<RootObject> {
    return this._http.get<RootObject>("https://api.exchangeratesapi.io/latest?symbols=" + convert + "&base=" + base)
  }
  info: RootObject;
}

export interface RootObject {
  base: string;
  rates: number[];
  date: string;
}
