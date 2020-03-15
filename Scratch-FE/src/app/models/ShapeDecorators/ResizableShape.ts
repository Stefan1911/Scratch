import { Drawable } from '../interfaces/initializable';
import { ShapeModel } from '../ShapeModel';
import { PointModel } from '../PointModel';
import { ShapeHelperModel } from '../HelperModels/shapeHelperModel';
import * as createjs from 'createjs-module';

export class ResizableShape extends createjs.Container implements Drawable{

    private decorator: createjs.Shape;
    constructor(private shape :Drawable) {
        super();
        this.decorator = new createjs.Shape();

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
        this.addChild(this.decorator);
        this.addChild(this.shape);
    }

    initializeDecorator(){
        this.decorator.graphics.clear();
        let pointOne = this.shape.points[0];
        let pointTwo = this.shape.points[1];
        let width = pointTwo.x - pointOne.x;
        let heigth = pointTwo.y - pointOne.y;
        this.decorator.graphics.beginFill("#ffffff").beginStroke("#ffffff").drawRect(pointOne.x - 20,pointOne.y - 20,width + 40,heigth + 40)
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