import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from 'src/app/models/UserModel';

@Injectable({
	providedIn: 'root'
})
export class PutService{
	constructor(private http : HttpClient ) {
	}

    updateUser(user : UserModel){
        return this.http.put("http://localhost:5000/api/user/",user)
    }
}