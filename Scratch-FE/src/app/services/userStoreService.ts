import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';

@Injectable({
	providedIn: 'root'
})
export class UserStore
{
    user : UserModel;
    constructor() {
    }

    get isLogedIn(){
        return !(this.user == undefined || this.user == null);
    }
}