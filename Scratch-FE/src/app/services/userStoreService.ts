import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';

@Injectable({
	providedIn: 'root'
})
export class UserStore
{
    userKay: string = "userKey"
    private _user : UserModel;
    constructor() {
    }

    get isLogedIn(){
        return !(this.user == undefined || this.user == null);
    }
    set user(user: UserModel){
        localStorage.setItem(this.userKay, JSON.stringify(user));
        this._user = user;
    }
    get user(){
        if(this._user != null && this._user != undefined ){
            return this._user
        }
        this._user = JSON.parse(localStorage.getItem(this.userKay));
        console.log("user on get");
        console.log(this._user);
        
        
        return this._user
    }
}