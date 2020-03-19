import { Drawable } from '../interfaces/initializable';
import { ShapeModel } from '../ShapeModel';
import { PointModel } from '../PointModel';
import { ShapeHelperModel } from '../HelperModels/shapeHelperModel';
import * as createjs from 'createjs-module';
import { create } from 'domain';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';

export class ResizableShape extends createjs.Container implements Drawable{

    private decorator: createjs.Shape;
    private decoratrList: createjs.Shape[];
    constructor(private shape :Drawable,private canvas : AppCanvasComponent) {
        super();
        this.decorator = new createjs.Shape();
        this.decoratrList = new Array();

    }
    peelDecoration(): Drawable {
        return this.shape.peelDecoration();
    }
    fromShapeHelper(shape: ShapeHelperModel) {
        this.shape.fromShapeHelper(shape);
    }

    initializeDrowing() {
        this.removeAllChildren();
        this.initializeDecorator()
        this.shape.initializeDrowing();
        this.addChild(this.shape);
        this.decoratrList.forEach(element => {
            this.addChild(element);
        });        
    }

    initializeDecorator(){

        this.decoratrList = new Array();
        this.shape.points.forEach((point,index) => {
            let pointDecorator = new createjs.Shape;
            pointDecorator.graphics
                .beginFill("#850c68")
                .beginStroke("#ffffff")
                .drawCircle(point.x,point.y,30);
            this.setupEvents(pointDecorator,index);
            this.decoratrList.push(pointDecorator)
        });
    }

    setupEvents(pointDecorator : createjs.Shape,index :number){
        pointDecorator.on("pressmove", (event : createjs.MouseEvent) => {
            this.shape.points[index].x = event.stageX;
            this.shape.points[index].y = event.stageY;
            this.shape.initializeDrowing();
            this.canvas.stage.update();
        });
        pointDecorator.on("pressup", (event: createjs.MouseEvent) => {
            this.canvas.postService.updateShape(this.canvas.conncionID,this.shape);
        })
    }
    get shapeIndex() : number{
        return this.shape.shapeIndex;
    }
    set shapeIndex(index : number){
        this.shape.shapeIndex = index;
    }

    get tableId() : string{
        return this.shape.tableId;
    }

    set tableId(id : string){
        this.shape.tableId = id
    }

    get points() : PointModel[]{
        return this.shape.points;
    }

    set points(value : PointModel[]){
        this.shape.points = value
    }

    get fillColor() : string{
        return this.shape.fillColor;
    }

    set fillColor(value : string){
        this.shape.fillColor = value
    }

    get strockColor() : string{
        return this.shape.strockColor;
    }

    set strockColor(value : string){
        this.shape.strockColor = value
    }

    get type() : string{
        return this.shape.type;
    }

    set type(value : string){
        this.shape.type = value
    }

    get sendingClientID() : string{
        return this.shape.sendingClientID;
    }

    set sendingClientID(value : string){
        this.shape.sendingClientID = value
    }
}