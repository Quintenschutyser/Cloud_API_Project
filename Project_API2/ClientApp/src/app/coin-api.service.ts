import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoinApiService {

  constructor(private _http: HttpClient) { }

  baseCoin: string = "EUR";

  getInfo(): Observable<RootObject> {
    return this._http.get<RootObject>("https://api.exchangeratesapi.io/latest?symbols=USD,GBP")
  }
  info: RootObject;
}

export interface Rates {
  USD: number;
  GBP: number;
}

export interface RootObject {
  base: string;
  rates: Rates;
  date: string;
}
