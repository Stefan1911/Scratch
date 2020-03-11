import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { UserModel } from 'src/app/models/UserModel';
import { LogInService } from 'src/app/services/httpServices/LogInService';
import { UserStore } from 'src/app/services/userStoreService';
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

  constructor(private logInService : LogInService,private userStore : UserStore, public dialogRef: MatDialogRef<ProfileComponent>) { 
    this.name=userStore.user.name;
    this.email=userStore.user.email;
    this.username=userStore.user.username;
    this.pictureUrl=userStore.user.pictureUrL;
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
  }
  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }
  ngOnInit() {
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
