import { Point, MouseEvent, Shape, DisplayObject } from 'createjs-module';
import { ShapeSubjectService } from '../ShapeSubjectService';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { PointModel } from 'src/app/models/PointModel';
import { PostService } from '../httpServices/postService';

export class SelectorTool{
    isMousDown : boolean = false;
    SelectedObject: DisplayObject;
	previousPoint: Point;
	totalXDistance: number = 0;
	totalYDistance: number = 0;
    onMousMoveEvent;

    constructor(private canvas : AppCanvasComponent) {
    }
    onMousDown(event : MouseEvent){
        this.SelectedObject = this.canvas.stage.getObjectUnderPoint(event.stageX,event.stageY,0);
        this.previousPoint = new Point(event.stageX,event.stageY);        
		this.isMousDown = true;
		this.totalXDistance = 0;
		this.totalYDistance = 0;
    }
    onMouseUp(event : MouseEvent){
        
        let shapeIndex = this.canvas.stage.getChildIndex(this.SelectedObject);
        console.log({log:"onMousUp at selector tool",shapes: this.canvas.shapes,shapeIndex});
        this.updateShapePoints(shapeIndex,this.totalXDistance,this.totalYDistance);
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
            this.canvas.stage.update();
        }
    }


    updateShapePoints(shapeIndex:number, xMovement:number, yMovement:number){
        this.canvas.shapes[shapeIndex].shapeIndex = shapeIndex;
        this.canvas.shapes[shapeIndex].points.map((point)=>{
            point.x += xMovement;
            point.y += yMovement
        });
        this.canvas.postService.updateShape(this.canvas.conncionID,this.canvas.shapes[shapeIndex]);
    }

}