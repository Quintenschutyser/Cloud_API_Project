import { Component, OnInit } from '@angular/core';
import { OwnApiService, RootUser, RootLand } from "../own-api.service";
import { log } from 'util';

@Component({
  selector: 'app-showdata',
  templateUrl: './showdata.component.html',
  styleUrls: ['./showdata.component.css']
})
export class ShowdataComponent implements OnInit {

  dataArrayLand: RootLand;
  dataArrayUser: RootUser;

  createLand: RootLand = {
    'id': 1,
    'alpha3Code': "EUR",
    'name': "test",
    'currency': "EUR"
  };
  createUser: RootUser = {
    'id': 1,
    'firstName': "st",
    'lastName': "testtest"
  };

  constructor(private dataSvc: OwnApiService) { }

  ngOnInit() {
    this.dataSvc.getLands().subscribe(land => {
      this.dataArrayLand = land;
    })
    this.dataSvc.getUsers().subscribe(user => {
      this.dataArrayUser = user;
    })
  }

  addUser(first: string, last: string) {
    this.createUser.firstName = first;
    this.createUser.lastName = last;
    this.dataSvc.addUser(this.createUser);
  }

  addLand(name: string, code: string, curr: string) {
    this.createLand.name = name;
    this.createLand.alpha3Code = code;
    this.createLand.currency = curr;
    this.dataSvc.addLand(this.createLand);
  }
  dellLand(id: number) {
    this.dataSvc.delLand(id);
  }
  dellUser(id: number) {
    this.dataSvc.delUser(id);
  }
}
