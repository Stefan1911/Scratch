import { PointModel } from '../PointModel';
import { Drawable } from '../interfaces/initializable';

export class ShapeHelperModel {
	id : string;
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
		this.id = shape.shapeId;
		this.shapeIndex = shape.shapeIndex;
		this.tableId = shape.tableId;
		this.points = shape.points;
		this.fillColor = shape.fillColor;
		this.strockColor = shape.strockColor;
		this.type = shape.type;
		this.sendingClientID = shape.sendingClientID;
	}
}