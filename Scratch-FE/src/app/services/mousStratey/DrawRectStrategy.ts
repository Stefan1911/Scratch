import { Point, MouseEvent, Shape, Rectangle } from 'createjs-module';
import { PointModel } from 'src/app/models/PointModel';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { ShapeFactory } from './Factories/ShapeFactory';
import { Drawable, ShapeNames } from 'src/app/models/interfaces/Drawable';

export class DrawRectStrategy{
    isMousDown : boolean = false;
    topLeftCorner : Point;
    minDrawingWidth:number = 2;
    minDrawingHeigth:number = 2;
    defaultWidth = 100;
    defaultHeigth = 100;
	currentShapeModel :Drawable;
    stage : createjs.Stage;

    constructor(private canvas: AppCanvasComponent,private shapeType : ShapeNames,private shapeFactory: ShapeFactory) {
        this.stage = canvas.stage;
    }
    onMousDown(event : MouseEvent){
        this.createDefaultShape();
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
        this.canvas.shapeService.sendShape(this.canvas.conncionID,this.currentShapeModel)
        .subscribe( (shape : ShapeHelperModel) => {
            this.currentShapeModel.shapeId = shape.id;
            console.log(this.currentShapeModel);
            
        })	
        
        
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

    createDefaultShape(){
        this.currentShapeModel = this.shapeFactory.getShape(this.shapeType);
        this.currentShapeModel.tableId = this.canvas.drawingBoardId;
        this.currentShapeModel.points = new Array();
        this.currentShapeModel.points.push(new PointModel(0,0));
        this.currentShapeModel.points.push(new PointModel(0,0));
    }
}