import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { UserModel } from 'src/app/models/UserModel';
import { LogInService } from 'src/app/services/httpServices/LogInService';
import { UserStore } from 'src/app/services/userStoreService';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  name:String;
  username:String;
  pictureUrl:String;
  email:String;
  oldName:String;
  oldUsername:String;
  oldEmail:String;

  constructor(private logInService : LogInService,private userStore : UserStore, public dialogRef: MatDialogRef<ProfileComponent>, private _snackBar: MatSnackBar) { 
    this.name=userStore.user.name;
    this.email=userStore.user.email;
    this.username=userStore.user.username;
    this.pictureUrl=userStore.user.pictureUrl;
    this.oldName=userStore.user.name;
    this.oldEmail=userStore.user.email;
    this.oldUsername=userStore.user.username;
  }
  
  submit(){
    let user : UserModel = new UserModel();
    user.email  = this.email;
    user.name = this.name;
    user.username = this.username;
    user.id=this.userStore.user.id;
 
    this.logInService.updateUser(user).subscribe((response : UserModel) => {
      if(response != null && response != undefined){
        this.userStore.user = response;
      }
    });
    this.openSnackBar();
  }
  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }
  openSnackBar() {
    this._snackBar.open("User updated","", {
      duration: 2500,
    });
  }
  ngOnInit() {
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
