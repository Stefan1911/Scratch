import { DrawingBoardModel } from './DrawingBoardModel';
import { UserModel } from './UserModel';

export class ProjectModel {
	
	id : string;
	tables :DrawingBoardModel [];
    name: string;
    description:string;
    pictureUrl:string;
	userIDs:string[];
	constructor(name: string, descriptopn: string,pictureUrl:string) {
        this.name=name;
        this.description=descriptopn;
        this.pictureUrl=pictureUrl;
	}


}