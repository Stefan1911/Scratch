import { Point, MouseEvent, Shape } from 'createjs-module';

export class DrawRectStrategy{
    isMousDown : boolean = false;
    topLeftCorner : Point;
    minDrawingWidth:number = 2;
    minDrawingHeigth:number = 2;
    defaultWidth = 100;
    defaultHeigth = 100;
    CurrentlyDrawingShape : createjs.Shape;

    constructor(private stage : createjs.Stage) {
    }
    onMousDown(event : MouseEvent){
        this.topLeftCorner = new Point(event.stageX,event.stageY);
        this.CurrentlyDrawingShape = new Shape();
        this.CurrentlyDrawingShape.graphics
                                .beginStroke("#000000")
                                .beginFill("#ffffff")
                                .drawRect(this.topLeftCorner.x,this.topLeftCorner.y,this.minDrawingWidth,this.minDrawingHeigth);
        
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
                        .beginStroke("#000000")
                        .beginFill("#ffffff")
                        .drawRect(this.topLeftCorner.x,this.topLeftCorner.y,this.defaultWidth,this.defaultHeigth);
                this.stage.update();
        }
        this.topLeftCorner = null;
        
    }
    onMouseMove(event : MouseEvent){
       
        if(this.isMousDown){
            let widht = (event.stageX-this.topLeftCorner.x);
            let heigth = (event.stageY - this.topLeftCorner.y);
            if(Math.abs(widht) > this.minDrawingWidth && Math.abs(heigth) > this.minDrawingHeigth){
                this.CurrentlyDrawingShape.graphics
                        .clear()
                        .beginStroke("#000000")
                        .beginFill("#ffffff")
                        .drawRect(this.topLeftCorner.x,this.topLeftCorner.y,widht,heigth);
                this.stage.update();
            }
        }
    }
}