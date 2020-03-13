import { Point, MouseEvent, Shape, Rectangle } from 'createjs-module';
import { Subject } from 'rxjs';
import { ShapeModel } from 'src/app/models/ShapeModel';
import { ShapeSubjectService } from '../ShapeSubjectService';
import { PointModel } from 'src/app/models/PointModel';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';

export class DrawRectStrategy{
    isMousDown : boolean = false;
    topLeftCorner : Point;
    minDrawingWidth:number = 2;
    minDrawingHeigth:number = 2;
    defaultWidth = 100;
    defaultHeigth = 100;
	currentShapeModel :ShapeModel;
    stage : createjs.Stage;

    constructor(private canvas: AppCanvasComponent) {
        this.stage = canvas.stage;
		this.currentShapeModel = new ShapeModel();
		this.currentShapeModel.fillColor = "#000000";
		this.currentShapeModel.strockColor = "DeepSkyBlue";
        this.currentShapeModel.type = "Rectangle";
        this.currentShapeModel.tableId = canvas.drawingBoardId;
        this.currentShapeModel.points = new Array();
        this.currentShapeModel.points.push(new PointModel(0,0));
        this.currentShapeModel.points.push(new PointModel(0,0));
    }
    onMousDown(event : MouseEvent){
        this.topLeftCorner = new Point(event.stageX,event.stageY);
        this.currentShapeModel.points[0] = new PointModel(this.topLeftCorner.x,this.topLeftCorner.y);
        this.currentShapeModel.points[1] = new PointModel(this.topLeftCorner.x+this.defaultWidth,this.topLeftCorner.y+this.defaultHeigth);
        this.canvas.shapes.push(this.currentShapeModel);
        this.stage.addChild(this.currentShapeModel);
        this.isMousDown = true;
    }
    onMouseUp(event : MouseEvent){
        this.isMousDown = false;
        if(this.topLeftCorner.x == event.stageX && this.topLeftCorner.y == event.stageY){
            this.topLeftCorner = new Point(event.stageX - (this.defaultWidth/2), event.stageY - (this.defaultHeigth/2));
			this.currentShapeModel.shapeIndex = this.stage.getChildIndex(this.currentShapeModel);
			this.currentShapeModel.points[0] = new PointModel(this.topLeftCorner.x,this.topLeftCorner.y);
			this.currentShapeModel.points[1] = new PointModel(this.topLeftCorner.x+this.defaultWidth,this.topLeftCorner.y+this.defaultHeigth);
			this.canvas.reDrawAllShapes();
        }	
        this.canvas.postService.sendShape(this.canvas.conncionID,this.currentShapeModel);	
        
        
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown){
            let widht = (event.stageX-this.topLeftCorner.x);
            let heigth = (event.stageY - this.topLeftCorner.y);
            if(Math.abs(widht) > this.minDrawingWidth && Math.abs(heigth) > this.minDrawingHeigth){
                this.currentShapeModel.points[1] = new PointModel(event.stageX,event.stageY);
                this.canvas.reDrawShape(this.currentShapeModel);
            }
        }
    }
}