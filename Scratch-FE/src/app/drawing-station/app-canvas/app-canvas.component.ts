import { Component, OnInit, Input } from '@angular/core';
import * as createjs from 'createjs-module';
import { MouseStrategyFactory, MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';
import { ShapeSubjectService } from 'src/app/services/ShapeSubjectService';
import { PostService } from 'src/app/services/httpServices/postService';
import { SignalRResiver } from 'src/app/services/httpServices/signalRReciver';
import { GetService } from 'src/app/services/httpServices/getService';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { ShapeModel } from 'src/app/models/ShapeModel';
import { PointModel } from 'src/app/models/PointModel';
import { MAT_LABEL_GLOBAL_OPTIONS } from '@angular/material/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-canvas',
  templateUrl: './app-canvas.component.html',
  styleUrls: ['./app-canvas.component.css'],
  providers: [MouseStrategyFactory]
})
export class AppCanvasComponent implements OnInit {

	mouseStrategy : any;
	stage;
	mousDownListener;
	mousMoveListener;
	mousUpListener;
	@Input()
	drawingBoardId : string;
	@Input()
	projectId :string;
	drawingBoard : DrawingBoardModel
	shapeSubjects = new ShapeSubjectService();
	conncionID : string ;
	shapes: ShapeModel[];

	subscriptions : Subscription[];
  
  constructor(private strategyFactory : MouseStrategyFactory
			,private postService: PostService
			,private reciver : SignalRResiver 
			,private getService : GetService
			) { 
				this.shapes = new Array();
			}

	ngOnInit() {
		this.initShapes(this.drawingBoardId);
	}

	initShapes(boardId : string){
	//	console.log("init shape has been called for the table " + boardId);
		
		this.drawingBoardId = boardId;
		if(this.checkString(this.drawingBoardId)&& this.checkString(this.projectId)){
			this.getService.getTable(this.projectId,this.drawingBoardId)
			.subscribe((drawingBoard: DrawingBoardModel) => {
				this.DrawAllShapes(drawingBoard.shapes);
			})
			this.reciver
				.registerDrawingStation(this)
				.then( (mightBeTheId) =>{
					this.conncionID = mightBeTheId
				})
			this.strategyFactory.setShapeSubject(this.shapeSubjects);
			this.setUpShapeSubscriptions();
			this.stage = new createjs.Stage("demoCanvas");
			this.setTool(MouseStrategyEnum.selector);
			this.stage.addEventListener("added", (event) => console.log(event));
			this.stage.update();
		}
	}

	setTool( tool:MouseStrategyEnum){
		this.stage.removeAllEventListeners("stagemousedown");
		this.stage.removeAllEventListeners("stagemousemove");
		this.stage.removeAllEventListeners("stagemouseup");

		this.mouseStrategy = this.strategyFactory.getMousStrategy(tool,this.stage);

		this.stage.addEventListener("stagemousedown" , (event) => {this.mouseStrategy.onMousDown(event)});
		this.stage.addEventListener("stagemousemove" , (event) => {this.mouseStrategy.onMouseMove(event)});
		this.stage.addEventListener("stagemouseup" , (event) => {this.mouseStrategy.onMouseUp(event)});
	}

	setUpShapeSubscriptions(){
		this.subscriptions = new Array();
		let temp = this.shapeSubjects.shapeCreatedSubject.subscribe( shape => {
			shape.tableId = this.drawingBoardId;
			this.shapes.push(shape);
			this.postService.sendShape(this.conncionID,shape);
		});
		this.subscriptions.push(temp);

		temp = this.shapeSubjects.moveSubject.subscribe ( movemant => {
			console.log(movemant);
			
			this.shapes[movemant.shapeIndex].shapeIndex = movemant.shapeIndex;
			for (let index = 0; index < this.shapes[movemant.shapeIndex].points.length; index++) {
				const element = this.shapes[movemant.shapeIndex].points[index];
				let newPoint = new PointModel(element.x + movemant.xMovement,element.y + movemant.yMovement);
				this.shapes[movemant.shapeIndex].points[index] = newPoint;
			}			
			this.postService.updateShape(this.conncionID,this.shapes[movemant.shapeIndex]);
		});
		this.subscriptions.push(temp);
	}
	killSubscrioption(){
		if(this.subscriptions != null && this.subscriptions != undefined){
			this.subscriptions.forEach(subscription => {
				subscription.unsubscribe();
			});
		}
	}

	DrawAllShapes( shapes:ShapeModel[]){
		shapes.forEach((shape) =>{
			shape.tableId = this.drawingBoardId;
			this.shapes.push(shape);
			this.drawShape(shape);
		})
	}

	drawShape(shape:ShapeModel){
		let newShape = new createjs.Shape();
		if(shape.type == "Rectangle"){
			let pointOne = shape.points[0];
			let pointTwo = shape.points[1];
			let width = pointTwo.x - pointOne.x;
			let heigth = pointTwo.y - pointOne.y;
			newShape.graphics.beginFill("DeepSkyBlue").beginStroke("#000000").drawRect(pointOne.x,pointOne.y,width,heigth);
			this.stage.addChild(newShape)
		}
		this.stage.update();
	}

	updateShape(shape:ShapeModel, shapeIndex:number){
		let newShape = new createjs.Shape();
		if(shape.type == "Rectangle"){
			let pointOne = shape.points[0];
			let pointTwo = shape.points[1];
			let width = pointTwo.x - pointOne.x;
			let heigth = pointTwo.y - pointOne.y;
			newShape.graphics.beginFill("DeepSkyBlue").beginStroke("#000000").drawRect(pointOne.x,pointOne.y,width,heigth);
			this.stage.removeChildAt(shapeIndex);
			this.stage.addChildAt(newShape,shapeIndex)
		}
		this.stage.update();
	}

	checkString(str:String) : boolean{
		return str!=undefined&&str!=null&&str!="";
	}
}
