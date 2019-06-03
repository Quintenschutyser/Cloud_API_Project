import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { rootRenderNodes } from '@angular/core/src/view';


@Injectable({
  providedIn: 'root'
})
export class OwnApiService {

  constructor(private _http: HttpClient) { }

  getLands(): Observable<RootLand> {
    return this._http.get<RootLand>("http://localhost:53438/api/v2/land")
  }
  getUsers(): Observable<RootUser> {
    return this._http.get<RootUser>("http://localhost:53438/api/v2/user")
  }

  info: RootLand;
  info2: RootUser;
}

export interface RootLand {
  id: number;
  name: string;
  currency: string;
  alpha3Code: string;
}

export interface RootUser {
  id: number;
  firstName: string;
  lastName: string;
}
