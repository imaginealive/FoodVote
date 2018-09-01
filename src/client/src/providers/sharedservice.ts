import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../app/model';
import { UserserviceProvider } from '../providers/userservice';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/timeout';
/*
  Generated class for the SharedserviceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class SharedserviceProvider {
  constructor(public http: HttpClient,private userservice: UserserviceProvider) {
    console.log('Hello SharedserviceProvider Provider');
  }
  
  login(username:string) {
    var acc = this.http.get('http://captainapi.azurewebsites.net/api/account/getaccount/'+ username)
    .map(res => <Account>res)
    .toPromise<Account>();
    acc.then(user => {console.log(user); this.userservice.Username = user.username;});
  }
}