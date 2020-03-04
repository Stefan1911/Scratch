import { Component, OnInit } from '@angular/core';
import { UserStore } from 'src/app/services/userStoreService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  name: string;
  pictureUrl: string;
  constructor(private userStore: UserStore, private Router : Router) {
    this.name="Minja";
    this.pictureUrl="https://images.pexels.com/photos/300857/pexels-photo-300857.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940";
   }

  ngOnInit() {
  }

  get IsLogedIn(){
    return this.userStore.isLogedIn;
  }

  redirectToLogin(){
    this.Router.navigate(["login"]);
  }

}
