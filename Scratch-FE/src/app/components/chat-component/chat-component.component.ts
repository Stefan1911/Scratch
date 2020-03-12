import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';

@Component({
  selector: 'app-chat-component',
  templateUrl: './chat-component.component.html',
  styleUrls: ['./chat-component.component.scss']
})
export class ChatComponentComponent implements OnInit {
  im="https://akcreativedesign.com/wp-content/uploads/2018/09/3screens-1024x683.jpg";
  users: UserModel[];
  constructor() { 
    var proj=new UserModel();
    proj.pictureUrL="https://akcreativedesign.com/wp-content/uploads/2018/09/3screens-1024x683.jpg";
    proj.name="ma ddsddsdfb re";
    this.users=new Array();
    this.users.push(proj);
    this.users.push(proj);
    this.users.push(proj);
    this.users.push(proj);
  }

  ngOnInit() {
  }
  

}
