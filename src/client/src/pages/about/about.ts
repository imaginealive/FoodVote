import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { CreatshopPage } from '../creatshop/creatshop';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {

  constructor(public navCtrl: NavController) {

  }

Createshop(){
  this.navCtrl.push(CreatshopPage);
}

}
