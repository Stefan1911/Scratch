import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  constructor() { }


  buttonText : String = "LogIn"
  isLogin : boolean = true;

  username : String;
  password : String;

  email : String;
  fullName : string;
  registerUsername : string;
  registerPassword : string;

  ngOnInit() {
  }

  selectionChanged(event : number){
    this.buttonText = (event === 0)? "LogIn":"Register";
    this.isLogin = (event === 0)? true:false;
  }

  submit(){
    console.table({emal : this.email , fullName : this.fullName , username : this.username , password : this.password, regUsername : this.registerUsername, regPass : this.registerPassword})

  }
}
