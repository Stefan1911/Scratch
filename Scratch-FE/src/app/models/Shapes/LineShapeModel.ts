import { PointModel } from '../PointModel';
import * as createjs from 'createjs-module';
import { ShapeHelperModel } from '../HelperModels/shapeHelperModel';
import { Drawable, ShapeNames } from '../interfaces/Drawable';

export class LineShapeModel extends createjs.Shape implements Drawable{
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
		this.type = ShapeNames[ShapeNames.Line];
	}
	peelDecoration() : Drawable {
		return this;
	}
	public fromShapeHelper(shape : ShapeHelperModel,tableId : string){
		this.shapeId = shape.id;
		this.shapeIndex = shape.shapeIndex;
		this.tableId = tableId;
		this.points = shape.points;
		this.fillColor = shape.fillColor;
		this.strockColor = shape.strockColor;
		this.type = shape.type;
		this.sendingClientID = shape.sendingClientID;
	}
	public initializeDrowing(){
		this.graphics.clear();
		let pointOne = this.points[0];
		let pointTwo = this.points[1];
		this.graphics
			.setStrokeStyle(20)
			.beginStroke(this.strockColor)
			.moveTo(pointOne.x,pointOne.y)
			.lineTo(pointTwo.x,pointTwo.y);
	}
}