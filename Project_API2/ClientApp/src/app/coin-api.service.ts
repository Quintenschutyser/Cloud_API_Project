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
  rates: Rates;
  date: string;
}

export interface Rates {
  BGN: number;
  NZD: number;
  ILS: number;
  RUB: number;
  CAD: number;
  USD: number;
  PHP: number;
  CHF: number;
  ZAR: number;
  AUD: number;
  JPY: number;
  TRY: number;
  HKD: number;
  MYR: number;
  THB: number;
  HRK: number;
  NOK: number;
  IDR: number;
  DKK: number;
  CZK: number;
  HUF: number;
  GBP: number;
  MXN: number;
  KRW: number;
  ISK: number;
  SGD: number;
  BRL: number;
  PLN: number;
  INR: number;
  RON: number;
  CNY: number;
  SEK: number;
}
