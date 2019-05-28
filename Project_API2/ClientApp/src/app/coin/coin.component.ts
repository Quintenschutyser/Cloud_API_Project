import { Component, OnInit } from '@angular/core';
import { CoinApiService, RootObject } from '../coin-api.service';
import { log } from 'util';

@Component({
  selector: 'app-coin',
  templateUrl: './coin.component.html',
  styleUrls: ['./coin.component.css']
})
export class CoinComponent implements OnInit {
  CoinArray: RootObject;
  converData: number = 1;
  baseData: number = 1;

  constructor(private CoinSvc: CoinApiService) { }

  ngOnInit() {
    this.CoinSvc.getInfo("EUR", "").subscribe(coin => {
      this.CoinArray = coin;
      console.log(coin.rates);
    })
  }

  convertTo(base: string, convert: string) {
    this.CoinSvc.getInfo(base, convert ).subscribe(coin => {
      this.CoinArray = coin;
      //console.log(coin);
    })
    this.converData = this.CoinArray.rates[convert] * this.baseData;
  }
}
