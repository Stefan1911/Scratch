import { ShapeModel } from './ShapeModel';
import { ChatModel } from './ChatModel';

export class DrawingBoardModel {
	
	id : string;
	name : String;
	shapes: ShapeModel[];
	chat: ChatModel;
	
	
	constructor() {
	}


}