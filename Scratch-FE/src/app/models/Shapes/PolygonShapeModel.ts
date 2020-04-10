import { PointModel } from '../PointModel';
import * as createjs from 'createjs-module';
import { ShapeHelperModel } from '../HelperModels/shapeHelperModel';
import { Drawable, ShapeNames } from '../interfaces/Drawable';
import { areAllEquivalent } from '@angular/compiler/src/output/output_ast';

export class PolygonShapeModel extends createjs.Shape implements Drawable{
	shapeId : string
	shapeIndex : number;
	tableId : string;
	points : PointModel[];
	fillColor : string;
	strockColor : string;
	type : string;
	sendingClientID :string

	constructor() {
		super();
		this.fillColor ="DeepSkyBlue";
		this.strockColor ="#000000";
		this.points = new Array;
		this.type = ShapeNames[ShapeNames.polygon];
	}
	peelDecoration() : Drawable {
		return this;
	}
	public fromShapeHelper(shape : ShapeHelperModel, tableId: string){
		this.shapeId = shape.id;
		this.shapeIndex = shape.shapeIndex;
		this.tableId = tableId;
		this.points = shape.points;
		this.fillColor = shape.fillColor;
		this.strockColor = shape.strockColor;
		this.type = shape.type;
	}
	public initializeDrowing(){
		this.graphics.clear();
		let pointOne = this.points[0];
		this.graphics
			.setStrokeStyle(20)
			.beginFill(this.fillColor)
			.beginStroke(this.strockColor)
			.moveTo(pointOne.x,pointOne.y)
		this.points.forEach( (point) => {
			this.graphics
				.lineTo(point.x,point.y)
		})
		this.graphics.lineTo(pointOne.x,pointOne.y);		
	}
}