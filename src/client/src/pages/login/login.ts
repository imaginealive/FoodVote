import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

import { HomePage } from '../home/home';
import { SharedserviceProvider } from '../../providers/sharedservice';
import { TabsPage } from '../tabs/tabs';
/**
 * Generated class for the LoginPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})

export class LoginPage {
  username : string;
  login(){
    this.sharedService.login(this.username);
    this.navCtrl.setRoot(TabsPage);
    this.navCtrl.popToRoot();
  }
  constructor(public navCtrl: NavController, public navParams: NavParams, private sharedService: SharedserviceProvider) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }

}