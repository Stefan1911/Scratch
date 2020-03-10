import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class ProjectService {
	constructor(private http: HttpClient) {
	}

	getProject(projetId:string){
		return this.http.get("http://localhost:5000/api/Project/"+projetId)
    }
    addDrawingBoard(projetId:string, boardName:string){
        return this.http.post("http://localhost:5000/api/DrawingBoard",{ProjectId : projetId, Name : boardName})
    }
}