import { Component } from '@angular/core';
import { NavController, Menu } from 'ionic-angular';
import { FormGroup,FormControl} from '@angular/forms';
import { LoginPage } from '../login/login';
import { SharedserviceProvider } from '../../providers/sharedservice';
import { UserserviceProvider } from '../../providers/userservice';
import { PollInfo, Menus } from '../../app/model';
import { Home2Page } from '../home2/home2';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  poll: PollInfo = new PollInfo("","","", new Date, false, null, []);
  newFood: string;
  voteId: string;
  closeEnable: boolean = false;
  havePoll: boolean = false;
  constructor(public navCtrl: NavController, private sharedService: SharedserviceProvider, private userService: UserserviceProvider) {
    var req = this.sharedService.getNewestPoll();
    req.then(data => {  
      if(data != null) {
        this.poll = data; 
        this.havePoll = this.poll != null; console.log(this.havePoll);
        this.closeEnable = this.poll.createBy == this.userService.Username;
        console.log(this.closeEnable);
        for(var i = 0; i < this.poll.menus.length; i++) {
          for(var j = 0; j < this.poll.menus[i].voter.length; j++) {
            if(this.poll.menus[i].voter[j] == this.userService.Username)
              this.voteId = this.poll.menus[i].id;
          }
        }
      }
      else 
      this.poll.shopName = "ยังไม่มีรายการโหวต";
    });
  }

  vote(foodId: string){
    this.voteId = foodId;
    console.log(this.voteId);
  }

  voteSubmit(){
    this.sharedService.vote(this.voteId).then(() => {
      var req = this.sharedService.getNewestPoll();
      req.then((data) => {this.poll = data;});
    })
  }

  AddNewFood(){
    this.sharedService.addNewMenu(this.newFood).then(() => {
      var req = this.sharedService.getNewestPoll();
      req.then((data) => {this.poll = data;});
    })
  }

  goLoginPage(){
    this.navCtrl.push(LoginPage)
  }

  closePoll(){
    this.sharedService.closePoll().then(() => {
      this.navCtrl.push(Home2Page);
    });
  }

}
