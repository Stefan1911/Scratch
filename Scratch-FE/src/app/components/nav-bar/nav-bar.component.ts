import { Component, OnInit } from '@angular/core';
import { UserStore } from 'src/app/services/userStoreService';
import { Router } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog'; 
import { ProfileComponent } from '../profile/profile.component';
import {ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  encapsulation: ViewEncapsulation.None 
})
export class NavBarComponent implements OnInit {

  name: String;
  pictureUrl: String;
  constructor(private userStore: UserStore, private Router : Router,public dialog: MatDialog) {
    this.pictureUrl="https://images.pexels.com/photos/300857/pexels-photo-300857.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940";
   }

  ngOnInit() {
    this.name = this.userStore.user.name;
  }

  get IsLogedIn(){
    if(this.userStore.isLogedIn){
      this.name = this.userStore.user.name;
      this.setPicture();
      return true;
    }
    return false;
  }
  
  setPicture(){
    this.pictureUrl=this.userStore.user.pictureUrL;
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      this.pictureUrl="https://img.icons8.com/plasticine/2x/gender-neutral-user.png";
  }
  
  redirectToLogin(){
    this.Router.navigate(["login"]);
  }

  onLogout(){
    this.userStore.user = null;
    this.Router.navigate(["home"])
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ProfileComponent, {
      panelClass: 'my-dialog'
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }
}
