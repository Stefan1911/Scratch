import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';
import { ChatModel } from 'src/app/models/ChatModel';
import { MessageModel } from 'src/app/models/MessageModel';

@Component({
  selector: 'app-chat-component',
  templateUrl: './chat-component.component.html',
  styleUrls: ['./chat-component.component.scss']
})
export class ChatComponentComponent implements OnInit {
  
  chat:ChatModel;
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
    this.chat=new ChatModel();
    var mes=new MessageModel();
    
    var ms=new MessageModel();
    ms.userName="ime2";
    ms.userPictureUrl="https://akcreativedesign.com/wp-content/uploads/2018/09/3screens-1024x683.jpg";
  ms.content="hshacdddddddddd   dddddddddddd dddddddddd dddddddddd  f";

  this.chat.messages=new Array();
    mes.userName="ime";
    mes.userPictureUrl="https://akcreativedesign.com/wp-content/uploads/2018/09/3screens-1024x683.jpg";
  mes.content="111111";
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(ms);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    this.chat.messages.push(mes);
    
  }

  ngOnInit() {
  }
  

}
