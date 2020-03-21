import { Point, MouseEvent, Shape, DisplayObject } from 'createjs-module';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { ResizableShape } from 'src/app/models/ShapeDecorators/ResizableShape';

export class SelectorTool{
    isMousDown : boolean = false;
    SelectedObject: DisplayObject;
	previousPoint: Point;
	totalXDistance: number = 0;
    totalYDistance: number = 0;
    shapeIndex : number

    constructor(private canvas : AppCanvasComponent) {
    }
    onMousDown(event : MouseEvent){
        this.peelDecoration();
        if(this.canvas.selectedShape !== null){
            this.canvas.selectedShape = null;
            this.canvas.shapeSelectionChaned.emit()
        }
		this.isMousDown = true;
        this.previousPoint = new Point(event.stageX,event.stageY);        
		this.totalXDistance = 0;
		this.totalYDistance = 0;
        this.SelectedObject = this.canvas.stage.getObjectUnderPoint(event.stageX,event.stageY,0);
        this.shapeIndex = this.canvas.stage.getChildIndex(this.SelectedObject);
        if(this.shapeIndex >= 0){
            this.setDecoratro(this.shapeIndex);
            this.canvas.shapeSelectionChaned.emit();
        }        
    }
    onMouseUp(event : MouseEvent){
        
        this.isMousDown = false;
        let shapeIndex = this.canvas.stage.getChildIndex(this.SelectedObject);
        if(shapeIndex >= 0 && (this.totalXDistance != 0 || this.totalYDistance != 0)){
            this.updateShapePoints(shapeIndex,this.totalXDistance,this.totalYDistance);
        }
        this.SelectedObject = null;
        this.previousPoint = null;
    }
    onMouseMove(event : MouseEvent){
        if(this.isMousDown && this.SelectedObject != null){
			let xDistance = event.stageX - this.previousPoint.x;
            let yDistance = event.stageY - this.previousPoint.y;
            this.updateShapePoints(this.shapeIndex,xDistance,yDistance);
            this.previousPoint = new Point(event.stageX,event.stageY); 
            this.canvas.reDrawShape(this.canvas.shapes[this.shapeIndex]);
        }
    }

    peelDecoration(){
        let index = this.canvas.stage.getChildIndex(this.canvas.selectedShape);
                
        if(index >= 0){
            let nonDecoratedShape = this.canvas.selectedShape.peelDecoration();
            this.canvas.shapes[index] = nonDecoratedShape;
            this.canvas.stage.removeChildAt(index);
            this.canvas.stage.addChildAt(nonDecoratedShape,index);
            this.canvas.reDrawShape(nonDecoratedShape);
        }
    }

    setDecoratro(shapeIndex : number){
        let temp = new ResizableShape(this.canvas.shapes[shapeIndex],this.canvas);
        this.canvas.shapes[shapeIndex] = temp;
        this.canvas.stage.removeChildAt(shapeIndex);
        this.canvas.stage.addChildAt(temp,shapeIndex);
        this.SelectedObject = temp;
        this.canvas.selectedShape = temp;
        this.canvas.reDrawShape(temp);
    }

    updateShapePoints(shapeIndex:number, xMovement:number, yMovement:number){
        this.canvas.shapes[shapeIndex].shapeIndex = shapeIndex;
        this.canvas.shapes[shapeIndex].points.map((point)=>{
            point.x += xMovement;
            point.y += yMovement;
        });
        this.canvas.shapeService.updateShape(this.canvas.conncionID,this.canvas.shapes[shapeIndex]);
    }

}