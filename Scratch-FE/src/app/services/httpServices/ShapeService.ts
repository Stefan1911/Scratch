import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { Drawable } from 'src/app/models/interfaces/Drawable';

const str = '{ "GivenFigure" : null, "PreviousGameState" : null, "NextGameState" : null }';
@Injectable({
	providedIn: 'root'
})
export class ShapeService{
	constructor(private http : HttpClient ) {
	}

	sendShape(connecionID:string ,shape : Drawable){
		let newShape = new ShapeHelperModel();
		newShape.fromShapeModel(shape);
		newShape.sendingClientID = connecionID;
		return this.http.post("http://localhost:5000/api/Shape",newShape)
	}

	updateShape(connecionID:string ,shape : Drawable){
		let newShape = new ShapeHelperModel();
		newShape.fromShapeModel(shape);
		newShape.sendingClientID = connecionID;
		this.http.put("http://localhost:5000/api/Shape",newShape)
			.subscribe();
	}

	deleteShape(connecionID:string ,tableId : string,shapeId : string){
		console.log({tableId,shapeId});
		
		return this.http.delete("http://localhost:5000/api/Shape/"+connecionID +"/"+ tableId+"/"+shapeId)
			.subscribe();
	}
}