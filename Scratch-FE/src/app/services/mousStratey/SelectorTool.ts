import { Point, MouseEvent, Shape, DisplayObject } from 'createjs-module';
import { ShapeSubjectService } from '../ShapeSubjectService';

export class SelectorTool{
    isMousDown : boolean = false;
    SelectedObject: DisplayObject;
    previousPoint: Point;
    onMousMoveEvent;

    constructor(private stage : createjs.Stage,shapeSubjects : ShapeSubjectService) {
    }
    onMousDown(event : MouseEvent){
        this.SelectedObject = this.stage.getObjectUnderPoint(event.stageX,event.stageY,0);
        this.previousPoint = new Point(event.stageX,event.stageY);        
        this.isMousDown = true;
    }
    onMouseUp(event : MouseEvent){
        this.isMousDown = false;
        this.SelectedObject = null;
        this.previousPoint = null;
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown && this.SelectedObject != null){
            this.SelectedObject.x += event.stageX - this.previousPoint.x;
            this.SelectedObject.y += event.stageY - this.previousPoint.y;
            this.previousPoint = new Point(event.stageX,event.stageY); 

            this.stage.update();
        }
    }

}