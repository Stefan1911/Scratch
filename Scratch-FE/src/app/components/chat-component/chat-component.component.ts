import { Component, OnInit} from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';
import { ChatModel } from 'src/app/models/ChatModel';
import { MessageModel } from 'src/app/models/MessageModel';
import { UserStore } from 'src/app/services/userStoreService';
import { MessageService } from 'src/app/services/httpServices/messageService';
import { SignalRResiver } from 'src/app/services/httpServices/signalRReciver';

@Component({
  selector: 'app-chat-component',
  templateUrl: './chat-component.component.html',
  styleUrls: ['./chat-component.component.scss']
})
export class ChatComponentComponent implements OnInit {
  
  chat:ChatModel;
  users: UserModel[];
  content:String;
  boardId:String;

  constructor(private messageService:MessageService,private userStore : UserStore, public reciver : SignalRResiver) { 
    var proj=new UserModel();
    this.users=new Array();
    this.chat=new ChatModel();
    var mes=new MessageModel();
    this.content = "";
  }

  chatInit(boardId: string){
    this.boardId=boardId;
    this.messageService.GetChat(boardId).subscribe((response : ChatModel) => {
      if(response != null && response != undefined){
       this.chat=response;
      }
    });
    this.reciver.registerChat(this);
  }
  send(){
    let message : MessageModel = new MessageModel();
    message.tableId=this.boardId;
    message.content=this.content;
    message.userId=this.userStore.user.id;
    message.userName=this.userStore.user.name;
    message.userPictureUrl=this.userStore.user.pictureUrl;
    this.messageService.PostMessage(message).subscribe((response : MessageModel) => {
      if(response != null && response != undefined){
        //this.chat.messages.push(response);
      }
    });
    this.content = "";
  }
  ngOnInit() {
  }
  
  onShowUsers()
  {
    this.messageService.GetUsers(this.boardId).subscribe((response : UserModel[]) => {
      if(response != null && response != undefined){
       this.users=response;
      }
    });
  }
}