import { Point, MouseEvent, Shape, Rectangle } from 'createjs-module';
import { Subject } from 'rxjs';
import { ShapeModel } from 'src/app/models/ShapeModel';
import { ShapeSubjectService } from '../ShapeSubjectService';
import { PointModel } from 'src/app/models/PointModel';

export class DrawRectStrategy{
    isMousDown : boolean = false;
    topLeftCorner : Point;
    minDrawingWidth:number = 2;
    minDrawingHeigth:number = 2;
    defaultWidth = 100;
    defaultHeigth = 100;
	CurrentlyDrawingShape : createjs.Shape;
	currentShapeModel :ShapeModel;


    constructor(private stage : createjs.Stage, private shapeSubjects : ShapeSubjectService) {
		this.currentShapeModel = new ShapeModel();
		this.currentShapeModel.fillColor = "#000000";
		this.currentShapeModel.strockColor = "DeepSkyBlue";
		this.currentShapeModel.type = "Rectangle";
		this.currentShapeModel.points = [];
    }
    onMousDown(event : MouseEvent){
        this.topLeftCorner = new Point(event.stageX,event.stageY);
		this.CurrentlyDrawingShape = new Shape();
		this.currentShapeModel.points.length = 0;
        this.CurrentlyDrawingShape.graphics
                                .beginStroke(this.currentShapeModel.fillColor)
                                .beginFill(this.currentShapeModel.strockColor)
								.drawRect(this.topLeftCorner.x,this.topLeftCorner.y,this.minDrawingWidth,this.minDrawingHeigth);
		this.currentShapeModel.points[0] = new PointModel(this.topLeftCorner.x,this.topLeftCorner.y);
        this.stage.addChild(this.CurrentlyDrawingShape);
        this.stage.update();
        this.isMousDown = true;
    }
    onMouseUp(event : MouseEvent){
        this.isMousDown = false;
        if(this.topLeftCorner.x == event.stageX && this.topLeftCorner.y == event.stageY){
            this.topLeftCorner = new Point(event.stageX - (this.defaultWidth/2), event.stageY - (this.defaultHeigth/2));
            this.CurrentlyDrawingShape.graphics
                        .clear()
                        .beginStroke(this.currentShapeModel.fillColor)
                        .beginFill(this.currentShapeModel.strockColor)
						.drawRect(this.topLeftCorner.x,this.topLeftCorner.y,this.defaultWidth,this.defaultHeigth);
			this.currentShapeModel.shapeIndex = this.stage.getChildIndex(this.CurrentlyDrawingShape);
			this.currentShapeModel.points[0] = new PointModel(this.topLeftCorner.x,this.topLeftCorner.y);
			this.currentShapeModel.points[1] = new PointModel(this.topLeftCorner.x+this.defaultWidth,this.topLeftCorner.y+this.defaultHeigth);
			this.stage.update();
		}		
		this.shapeSubjects.shapeCreatedSubject.next(this.currentShapeModel);
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown){
            let widht = (event.stageX-this.topLeftCorner.x);
            let heigth = (event.stageY - this.topLeftCorner.y);
            if(Math.abs(widht) > this.minDrawingWidth && Math.abs(heigth) > this.minDrawingHeigth){
                this.CurrentlyDrawingShape.graphics
                        .clear()
                        .beginStroke(this.currentShapeModel.fillColor)
                        .beginFill(this.currentShapeModel.strockColor)
						.drawRect(this.topLeftCorner.x,this.topLeftCorner.y,widht,heigth);
				this.currentShapeModel.points[1] = new PointModel(event.stageX,event.stageY);
                this.stage.update();
            }
        }
    }
}