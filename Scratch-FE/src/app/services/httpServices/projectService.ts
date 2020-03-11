import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectModel } from 'src/app/models/ProjectModel';

@Injectable({
	providedIn: 'root'
})
export class ProjectService{
	constructor(private http : HttpClient ) {
	}

    post(project : ProjectModel){
        return this.http.post("http://localhost:5000/api/project/",project)
    }
	getProject(projetId:string){
		return this.http.get("http://localhost:5000/api/Project/"+projetId)
    }
    addDrawingBoard(projetId:string, boardName:string,clientID :string){		
        return this.http.post("http://localhost:5000/api/DrawingBoard",{ProjectId : projetId, Name : boardName, ExcludedClientId: clientID})
    }
}