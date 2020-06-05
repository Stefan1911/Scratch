import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class TableService {
	constructor(private http: HttpClient) {
	}

	getTable(projectId:string , tableId:string){
		return this.http.get("http://localhost:5000/api/DrawingBoard/"+projectId+"/"+tableId)
	}
	renameTable(tableId:String,projectId:String, newName: String){
        return this.http.patch("http://localhost:5000/api/DrawingBoard/",{
				projectId:projectId,
				tableId:tableId,
				name:newName
		})
	}
	deleteTable(tableId:String, projectId:string ){
        return this.http.delete("http://localhost:5000/api/DrawingBoard/"+projectId+"/"+tableId)
	}
}