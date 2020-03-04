import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  name:string;
  username:string;
  pictureUrl:string;
  password:string;
  email:string;

  constructor() { 
    this.name="amor";
    //this.pictureUrl="https://themewagon.com/wp-content/uploads/2018/03/Profile-feat-Bootstrap-4-portfolio-website-template.jpg"
  }

  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }
  ngOnInit() {
  }

}
