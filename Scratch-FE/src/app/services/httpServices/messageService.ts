import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MessageModel } from 'src/app/models/MessageModel';

@Injectable({
	providedIn: 'root'
})
export class MessageService {
    constructor(private http : HttpClient) { }

    PostMessage(message : MessageModel){
        return this.http.post("http://localhost:5000/api/message/",message)
    }
    GetChat(boardId:string){
        return this.http.get("http://localhost:5000/api/chat/"+boardId)
    }
    GetUsers(boardId:String){
        return this.http.get("http://localhost:5000/api/chat/users/"+boardId)
    }
}