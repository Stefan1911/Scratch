import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { LogInService } from 'src/app/services/httpServices/LogInService';
import { UserModel } from 'src/app/models/UserModel';
import { UserStore } from 'src/app/services/userStoreService';
import { Router } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';
import { MatTabGroup } from '@angular/material/tabs';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  constructor(private logInService : LogInService, private userStore : UserStore,private router : Router, private _snackBar: MatSnackBar) { }

  @ViewChild("matTabGroup",{static : false})
  tabGroup : MatTabGroup;

  hide = true;
  buttonText : String = "LogIn";
  rout : string;
  isLogin : boolean = true;
  tabIndex : number

  username : String;
  password : String;

  email : String;
  fullName : string;
  registerUsername : string;
  registerPassword : string;

  ngOnInit() {
    let rout = this.router.routerState.snapshot.url;
    this.isLogin = (rout === "/login")? true : false;
    this.buttonText = (this.isLogin)? "LogIn":"Register";
    this.tabIndex = (rout === "/login")? 0 : 1;
  }

  selectionChanged(event : number){
    this.buttonText = (event === 0)? "LogIn":"Register";
    this.isLogin = (event === 0)? true:false;
  }

  submit(){
    //console.table({emal : this.email , fullName : this.fullName , username : this.username , password : this.password, regUsername : this.registerUsername, regPass : this.registerPassword})
    let user : UserModel = new UserModel();
    user.email  = this.email;
    user.name = this.fullName;
    user.username = (this.isLogin)? this.username : this.registerUsername;
    user.password = (this.isLogin)? this.password : this.registerPassword;
    user.pictureUrl="https://img.icons8.com/plasticine/2x/gender-neutral-user.png";
    
    this.logInService.PostUser(user,this.isLogin).subscribe((response : {user : UserModel,usernameIncorrect : boolean}) => {
      if(response.user != null && response.user != undefined){
        this.userStore.user = response.user;
        this.router.navigate(["projects"]);
      }
      else{
          this._snackBar.open("Incorrect password or username","", {
            duration: 2500,
          });
        
      }
    });
  }
}
