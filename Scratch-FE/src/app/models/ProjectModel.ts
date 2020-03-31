import { DrawingBoardModel } from './DrawingBoardModel';
import { UserModel } from './UserModel';

export class ProjectModel {
	
	id : string;
	drawingBoards :DrawingBoardModel [];
    name: string;
    description:string;
    pictureUrl:String;
	userIDs:String[];
	constructor(name: string, descriptopn: string,pictureUrl:string) {
        this.name=name;
        this.description=descriptopn;
        this.pictureUrl=pictureUrl;
	}


}