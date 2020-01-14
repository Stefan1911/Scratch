import { Component, OnInit } from '@angular/core';
import * as createjs from 'createjs-module';
import { MouseStrategyFactory, MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';
import { ShapeSubjectService } from 'src/app/services/ShapeSubjectService';
import { PostService } from 'src/app/services/httpServices/postService';
import { SignalRResiver } from 'src/app/services/httpServices/signalRReciver';
import { GetService } from 'src/app/services/httpServices/getService';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { ShapeModel } from 'src/app/models/ShapeModel';

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
	drawingBoardId = "5e19a1a48a5c6b319f4b8890";
	projectId = "5e02109ba8137e40119e51b6";
	drawingBoard : DrawingBoardModel
	shapeSubjects = new ShapeSubjectService();
	conncionID : string ;
  
  constructor(private strategyFactory : MouseStrategyFactory
			,private postService: PostService
			,private reciver : SignalRResiver 
			,private getService : GetService
			) { }

  ngOnInit() {
	this.getService.getTable(this.projectId,this.drawingBoardId)
	.subscribe((drawingBoard: DrawingBoardModel) => {
		this.DrawAllShapes(drawingBoard.shapes);
	})
	this.reciver.registerDrawingStation(this).then( (mightBeTheId) =>{
		this.conncionID = mightBeTheId
	})
	this.strategyFactory.setShapeSubject(this.shapeSubjects);
	this.setUpShapeSubscriptions();
    this.stage = new createjs.Stage("demoCanvas");
	this.setTool(MouseStrategyEnum.selector);
	this.stage.addEventListener("added", (event) => console.log(event));
    this.stage.update();
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
	this.shapeSubjects.shapeCreatedSubject.subscribe( shape => {
		shape.tableId = this.drawingBoardId;
		this.postService.sendShape(this.conncionID,shape);
	})
	}

	DrawAllShapes( shapes:ShapeModel[]){
		shapes.forEach((shape) =>{
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
}
