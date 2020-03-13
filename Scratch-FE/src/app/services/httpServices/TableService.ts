import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class TableService {
	constructor(private http: HttpClient) {
	}

	getTable(projetId:string , tableId:string){
		return this.http.get("http://localhost:5000/api/DrawingBoard/"+projetId+"/"+tableId)
	}
}