import { PointModel } from './PointModel';
import * as createjs from 'createjs-module';
import { ShapeHelperModel } from './HelperModels/shapeHelperModel';
import { Drawable } from './interfaces/initializable';

export class ShapeModel extends createjs.Shape implements Drawable{
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
	}
	peelDecoration() : Drawable {
		return this;
	}
	public fromShapeHelper(shape : ShapeHelperModel){
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
			this.graphics.beginFill("DeepSkyBlue").beginStroke("#000000").drawRect(pointOne.x,pointOne.y,width,heigth);
		}
	}
}