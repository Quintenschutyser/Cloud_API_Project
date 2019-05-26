import { Component, OnInit } from '@angular/core';
import { CountryAPiService, RootObject } from "../country-api.service";
import { Window } from 'selenium-webdriver';

declare var ol: any;

@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css']
})
export class WorldComponent implements OnInit {
  LandArray: RootObject;
  LandSpecifiek: RootObject;
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

    //voor openstreetmap
    this.map = new ol.Map({
      target: 'map',
      layers: [
        new ol.layer.Tile({
          source: new ol.source.OSM()
        })
      ],
      view: new ol.View({
        center: ol.proj.fromLonLat([73.8567, 18.5204]),
        zoom: 8
      })
    });
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
  showMap() {
    //voor openstreetmap
    this.map = new ol.Map({
      target: 'map',
      layers: [
        new ol.layer.Tile({
          source: new ol.source.OSM()
        })
      ],
      view: new ol.View({
        center: ol.proj.fromLonLat([73.8567, 18.5204]),
        zoom: 8
      })
    });
  }

  getInfoOf() {
    console.log(this.LandArray[0].currencies[0].code);
  }

  getSpecLand(alpha : string) {
    this.WorldSvc.getSpecifiek(alpha).subscribe(land => {
      this.LandSpecifiek = land;
      console.log(land);
    })
  }
}
