import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { SharedserviceProvider } from '../../providers/sharedservice';
import { PollInfo } from '../../app/model';

/**
 * Generated class for the Home2Page page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-home2',
  templateUrl: 'home2.html',
})
export class Home2Page {

  poll: PollInfo = new PollInfo("","","", new Date, false, null, []);
  havePoll: boolean = false;
  foodname: string;
  constructor(public navCtrl: NavController, public navParams: NavParams, private sharedService: SharedserviceProvider) {
    this.sharedService.getSubmitPoll().then((data) =>{
      if(data != null) {
      this.poll = data;
      this.havePoll = this.poll != null;
      this.foodname = this.poll.menus[0].menuName;
      }
    });
  }

  ionViewDidLoad() {
  }

}
