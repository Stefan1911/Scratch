import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from 'src/app/models/UserModel';

@Injectable({
	providedIn: 'root'
})
export class LogInService {
    constructor(private http : HttpClient) { }

    PostUser(user : UserModel,isLogIn = true){
        let endpoint = (isLogIn)?"login":"register";
        return this.http.post("http://localhost:5000/api/user/"+endpoint,user)
    }
}