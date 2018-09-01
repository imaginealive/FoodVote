import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HomePage } from '../home/home';
import { PollRequest } from '../../app/model';
import { SharedserviceProvider } from '../../providers/sharedservice';
import { TabsPage } from '../tabs/tabs';

/**
 * Generated class for the CreatshopPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-creatshop',
  templateUrl: 'creatshop.html',
})
export class CreatshopPage {

  request : PollRequest = new PollRequest("","","");
  constructor(public navCtrl: NavController, public navParams: NavParams, private sharedService: SharedserviceProvider) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad CreatshopPage');
  }
  onSubmit(){
    this.sharedService.createPoll(this.request).then((data) => {console.log(data);
      this.navCtrl.pop();
    });
}
}
