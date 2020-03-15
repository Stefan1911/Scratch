import { PointModel } from '../PointModel';
import { ShapeModel } from '../ShapeModel';
import { Drawable } from '../interfaces/initializable';

export class ShapeHelperModel {
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
	constructor() {}
	
	fromShapeModel(shape : Drawable){
		this.shapeIndex = shape.shapeIndex;
		this.tableId = shape.tableId;
		this.points = shape.points;
		this.fillColor = shape.fillColor;
		this.strockColor = shape.strockColor;
		this.type = shape.type;
		this.sendingClientID = shape.sendingClientID;
	}
}