import { Component, OnInit } from '@angular/core';
import { CoinApiService, RootObject } from '../coin-api.service';

@Component({
  selector: 'app-coin',
  templateUrl: './coin.component.html',
  styleUrls: ['./coin.component.css']
})
export class CoinComponent implements OnInit {
  CoinArray: RootObject;

  constructor(private CoinSvc: CoinApiService) { }

  ngOnInit() {
    this.CoinSvc.getInfo("EUR", "").subscribe(coin => {
      this.CoinArray = coin;
      console.log(coin);
    })
  }

  convertTo(base: string, convert: string) {
    this.CoinSvc.getInfo(base, convert ).subscribe(coin => {
      this.CoinArray = coin;
      console.log(coin);
    })
    console.log("convertTo works");
    console.log(base);
    console.log(convert)
  }

}
