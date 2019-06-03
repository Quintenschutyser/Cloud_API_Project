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

  createLand: RootLand;
  createUser: RootUser = {};

  constructor(private dataSvc: OwnApiService) { }

  ngOnInit() {
    this.dataSvc.getLands().subscribe(land => {
      this.dataArrayLand = land;
      console.log(land);
    })
    this.dataSvc.getUsers().subscribe(user => {
      this.dataArrayUser = user;
      console.log(user);
    })
  }

  addLand(first: string, last: string) {
    this.createUser.firstName = first;
    this.createUser.lastName = last;
    this.dataSvc.addUser(this.createUser);
  }

}
