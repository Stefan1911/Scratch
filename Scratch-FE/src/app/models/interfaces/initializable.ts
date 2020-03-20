import { PointModel } from '../PointModel';
import { ShapeHelperModel } from '../HelperModels/shapeHelperModel';
import { DisplayObject } from 'createjs-module';

export interface Drawable  extends DisplayObject {
	shapeId : string
    shapeIndex : number;
	tableId : string;
	points : PointModel[];
	fillColor : string;
	strockColor : string;
	type : string;
	sendingClientID :string

	peelDecoration() : Drawable;
    fromShapeHelper(shape : ShapeHelperModel);
    initializeDrowing();
}