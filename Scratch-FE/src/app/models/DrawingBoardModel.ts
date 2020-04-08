import { ChatModel } from './ChatModel';
import { ShapeHelperModel } from './HelperModels/shapeHelperModel';

export class DrawingBoardModel {
	
	id : string;
	name : String;
	shapes: ShapeHelperModel[];
	chat: ChatModel;
	
	
	constructor() {
	}


}