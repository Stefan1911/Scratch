import { PointModel } from './PointModel';
import * as createjs from 'createjs-module';
import { ShapeHelperModel } from './HelperModels/shapeHelperModel';
import { Drawable } from './interfaces/initializable';

export class ShapeModel extends createjs.Shape implements Drawable{
	shapeId : string
	shapeIndex : number;
	tableId : string;
	points : PointModel[];
	fillColor : string;
	strockColor : string;
	type : string;
	sendingClientID :string

	/**
	 *
	 */
	constructor() {
		super();
		this.fillColor ="DeepSkyBlue";
		this.strockColor ="#000000";
	}
	peelDecoration() : Drawable {
		return this;
	}
	public fromShapeHelper(shape : ShapeHelperModel){
		this.shapeId = shape.id;
		this.shapeIndex = shape.shapeIndex;
		this.tableId = shape.tableId;
		this.points = shape.points;
		this.fillColor = shape.fillColor;
		this.strockColor = shape.strockColor;
		this.type = shape.type;
		this.sendingClientID = shape.sendingClientID;
	}
	public initializeDrowing(){
		this.graphics.clear();
		if(this.type =="Rectangle"){
			let pointOne = this.points[0];
			let pointTwo = this.points[1];
			let width = pointTwo.x - pointOne.x;
			let heigth = pointTwo.y - pointOne.y;
			this.graphics
				.beginFill(this.fillColor)
				.beginStroke(this.strockColor)
				.drawRect(pointOne.x,pointOne.y,width,heigth);
		}
	}
}