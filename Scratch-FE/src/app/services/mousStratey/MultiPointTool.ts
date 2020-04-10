import {  MouseEvent, Shape } from 'createjs-module';
import { ShapeNames, Drawable } from 'src/app/models/interfaces/Drawable';
import { ShapeFactory } from './Factories/ShapeFactory';
import { PointModel } from 'src/app/models/PointModel';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
export class MultiPointTool{
    stage : createjs.Stage;
    drawingStarted : boolean = false;
    nextPoint : PointModel;
    CurrentlyDrawingShape : Drawable;
    constructor(private canvas: AppCanvasComponent,private shapeType : ShapeNames,private shapeFactory : ShapeFactory) {
        this.stage = canvas.stage;
    }
    onMousDown(event : MouseEvent){        
        if(this.drawingStarted === false){
            this.CurrentlyDrawingShape = this.shapeFactory.getShape(this.shapeType);
            this.nextPoint = new PointModel(event.stageX,event.stageY);
            this.CurrentlyDrawingShape.points.push(new PointModel(event.stageX,event.stageY),this.nextPoint);
            this.canvas.shapes.push(this.CurrentlyDrawingShape);
            this.stage.addChild(this.CurrentlyDrawingShape);
            this.stage.update();
            this.drawingStarted = true;
        }
        else{
            if(event.nativeEvent.button === 0){ // zero is the left mous button
                this.nextPoint = new PointModel(event.stageX,event.stageY);
                this.CurrentlyDrawingShape.points.push(this.nextPoint);
            }else if(event.nativeEvent.button === 2){ // 2 is the right mous button
                this.drawingStarted = false;
                this.CurrentlyDrawingShape.points.pop();
                this.canvas.reDrawShape(this.CurrentlyDrawingShape);
                this.canvas.saveShape(this.CurrentlyDrawingShape);	
            }
        }

    }
    onMouseUp(event : MouseEvent){
        
    }
    onMouseMove(event : MouseEvent){
        if(this.drawingStarted){
            this.nextPoint.x = event.stageX;
            this.nextPoint.y = event.stageY
            this.canvas.reDrawShape(this.CurrentlyDrawingShape);
        }
    }

}