import { Component, OnInit } from '@angular/core';
import { CountryAPiService, RootObject } from "../country-api.service";
import { Window } from 'selenium-webdriver';

@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css']
})
export class WorldComponent implements OnInit {
  LandArray: RootObject;
  SearchCountry: string;

  latitude: number = 50.83333333;
  longitude: number = 4;
  map: any;

  constructor(private WorldSvc: CountryAPiService) { }

  ngOnInit() {
    this.WorldSvc.getInfo(this.SearchCountry).subscribe(land => {
      this.LandArray = land;
      console.log(land);
    })
  }

  setCountry(country: string) {
    this.WorldSvc.getInfo(country).subscribe(land => {
      this.LandArray = land;
      console.log(land);
    })
  }

  goToUrl(land: string): void {
    //console.log(this.Land[0].latlng[1])
    //window.open("https://www.google.com/maps/?ll=" + this.Land[0].latlng[0] + "," + this.Land[0].latlng[1], "_blank");
    window.open("https://www.google.ca/maps/place/" + land);
  }
  setCenter() {
    var view = this.map.getView();
    view.setCenter();
    view.setZoom(8);
  }
}
