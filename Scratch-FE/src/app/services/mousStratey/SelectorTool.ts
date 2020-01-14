import { Point, MouseEvent, Shape, DisplayObject } from 'createjs-module';
import { ShapeSubjectService } from '../ShapeSubjectService';

export class SelectorTool{
    isMousDown : boolean = false;
    SelectedObject: DisplayObject;
	previousPoint: Point;
	totalXDistance: number = 0;
	totalYDistance: number = 0;
    onMousMoveEvent;

    constructor(private stage : createjs.Stage,private shapeSubjects : ShapeSubjectService) {
    }
    onMousDown(event : MouseEvent){
        this.SelectedObject = this.stage.getObjectUnderPoint(event.stageX,event.stageY,0);
        this.previousPoint = new Point(event.stageX,event.stageY);        
		this.isMousDown = true;
		this.totalXDistance = 0;
		this.totalYDistance = 0;
    }
    onMouseUp(event : MouseEvent){
		let shapeIndex = this.stage.getChildIndex(this.SelectedObject);
		this.shapeSubjects.moveSubject.next({shapeIndex : shapeIndex , xMovement: this.totalXDistance , yMovement : this.totalYDistance})
        this.isMousDown = false;
        this.SelectedObject = null;
        this.previousPoint = null;
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown && this.SelectedObject != null){
			let xDistance = event.stageX - this.previousPoint.x;
			let yDistance = event.stageY - this.previousPoint.y;
			this.totalXDistance += xDistance;
			this.totalYDistance += yDistance;
            this.SelectedObject.x += xDistance;
            this.SelectedObject.y += yDistance;
			this.previousPoint = new Point(event.stageX,event.stageY); 
            this.stage.update();
        }
    }

}