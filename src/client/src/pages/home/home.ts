import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { FormGroup,FormControl} from '@angular/forms';
import { LoginPage } from '../login/login';
import { SharedserviceProvider } from '../../providers/sharedservice';
import {
  FormGroup,
  FormControl

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  langs;
  langForm;

  constructor(public navCtrl: NavController, private sharedService: SharedserviceProvider) {
    var req = this.sharedService.getNewestPoll();
    req.then(data => console.log(data));
    this.langForm = new FormGroup({
      "langs": new FormControl({value: '', disabled: false})
    });
  }
  doSubmit(event) {
    console.log('Submitting form', this.langForm.value);
    event.preventDefault();
  }

  goLoginPage(){
    this.navCtrl.push(LoginPage)
  }

}
