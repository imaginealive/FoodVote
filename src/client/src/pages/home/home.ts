import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { FormGroup,FormControl} from '@angular/forms';
import { LoginPage } from '../login/login';
import { SharedserviceProvider } from '../../providers/sharedservice';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(public navCtrl: NavController, private sharedService: SharedserviceProvider) {
    //var req = this.sharedService.getNewestPoll();
    //req.then(data => console.log(data));
  }

  goLoginPage(){
    this.navCtrl.push(LoginPage)
  }

}
