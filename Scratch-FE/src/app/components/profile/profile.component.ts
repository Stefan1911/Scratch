import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { UserModel } from 'src/app/models/UserModel';
import { LogInService } from 'src/app/services/httpServices/LogInService';
import { UserStore } from 'src/app/services/userStoreService';
import {MatSnackBar} from '@angular/material/snack-bar';
import { PictureService } from 'src/app/services/httpServices/pictureService';
import { CloudinaryBackgroundImageDirective } from '@cloudinary/angular-5.x';

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
  uploadingFile: boolean = false;
  constructor(private pictureService : PictureService,private logInService : LogInService,private userStore : UserStore, public dialogRef: MatDialogRef<ProfileComponent>, private _snackBar: MatSnackBar) { 
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
    user.pictureUrl = this.pictureUrl;
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

  onImageChanged(event){
    this.uploadingFile = true;
    let selectedFile = event.target.files[0];
    this.pictureService.uploadImage(selectedFile)
      .subscribe( (response : {imageId:string}) => {
        let begining = "https://res.cloudinary.com/scratchimagestore/image/upload/";
        let index = begining.length -1;
        console.log(index);
        let circleImage = response.imageId.slice(0, index) + "w_1000,c_fill,ar_1:1,g_auto,r_max,bo_5px_solid_red,b_rgb:262c35/" + response.imageId.slice(index);
        this.pictureUrl = circleImage;
        console.log(circleImage);
        
        this.uploadingFile = false;
      })
  }
}
