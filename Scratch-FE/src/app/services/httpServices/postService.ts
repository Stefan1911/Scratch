import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShapeModel } from 'src/app/models/ShapeModel';

const str = '{ "GivenFigure" : null, "PreviousGameState" : null, "NextGameState" : null }';
@Injectable({
	providedIn: 'root'
})
export class PostService{
	constructor(private http : HttpClient ) {
	}

	sendShape(connecionID:string ,shape : ShapeModel){
		shape.sendingClientID = connecionID;
		this.http.post("http://localhost:5000/api/Shape",shape)
			.subscribe();
	}

	updateShape(connecionID:string ,shape : ShapeModel){
		shape.sendingClientID = connecionID;
		this.http.put("http://localhost:5000/api/Shape",shape)
			.subscribe();
	}
}