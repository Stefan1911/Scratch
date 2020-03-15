import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShapeModel } from 'src/app/models/ShapeModel';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { Drawable } from 'src/app/models/interfaces/initializable';

const str = '{ "GivenFigure" : null, "PreviousGameState" : null, "NextGameState" : null }';
@Injectable({
	providedIn: 'root'
})
export class ShapeService{
	constructor(private http : HttpClient ) {
	}

	sendShape(connecionID:string ,shape : ShapeModel){
		let newShape = new ShapeHelperModel();
		newShape.fromShapeModel(shape);
		newShape.sendingClientID = connecionID;
		this.http.post("http://localhost:5000/api/Shape",newShape)
			.subscribe();
	}

	updateShape(connecionID:string ,shape : Drawable){
		let newShape = new ShapeHelperModel();
		newShape.fromShapeModel(shape);
		newShape.sendingClientID = connecionID;
		this.http.put("http://localhost:5000/api/Shape",newShape)
			.subscribe();
	}
}