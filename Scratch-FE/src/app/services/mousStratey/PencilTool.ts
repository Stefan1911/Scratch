import {  MouseEvent, Shape } from 'createjs-module';
import { ShapeSubjectService } from '../ShapeSubjectService';

export class PencilTool{
    isMousDown : boolean = false;
    CurrentlyDrawingShape : createjs.Shape;
    constructor(private stage : createjs.Stage,shapeSubjects : ShapeSubjectService) {
    }
    onMousDown(event : MouseEvent){

        this.CurrentlyDrawingShape = new Shape();
        this.CurrentlyDrawingShape.graphics
                                .setStrokeStyle(10)
                                .beginStroke("DeepSkyBlue");
        this.stage.addChild(this.CurrentlyDrawingShape);
        this.stage.update();
        this.isMousDown = true;
    }
    onMouseUp(event : MouseEvent){
        this.isMousDown = false;
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown){
            let x = event.stageX;
            let y = event.stageY;
            this.CurrentlyDrawingShape.graphics.lineTo(x,y);
            this.stage.update();
        }
    }

}