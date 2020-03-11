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
	stage : createjs.Stage;
	mousDownListener;
	mousMoveListener;
	mousUpListener;
	@Input()
	drawingBoardId : string;
	@Input()
	projectId :string;
	drawingBoard : DrawingBoardModel;
	conncionID : string ;
	shapes: ShapeModel[];

	subscriptions : Subscription[];
  
  constructor(public strategyFactory : MouseStrategyFactory
			,public postService: PostService
			,public reciver : SignalRResiver 
			,public getService : GetService
			) { 
				this.shapes = new Array();
			}

	ngOnInit() {		
		this.initShapes(this.drawingBoardId);
	}

	initShapes(boardId : string){		
		this.drawingBoardId = boardId;
		this.shapes = new Array();
		if(this.checkString(this.drawingBoardId)&& this.checkString(this.projectId)){
			this.getService.getTable(this.projectId,this.drawingBoardId)
			.subscribe((drawingBoard: DrawingBoardModel) => {
				this.DrawAllShapes(drawingBoard.shapes);
			})
			this.reciver
				.registerCanvas(this)
				.then( (mightBeTheId) =>{
					this.conncionID = mightBeTheId
			});
			this.removeStageEventListeners();
			this.stage = new createjs.Stage("demoCanvas");
			this.setTool(MouseStrategyEnum.selector);
			this.stage.update();
		}
	}

	setTool( tool:MouseStrategyEnum){
		this.stage.removeAllEventListeners("stagemousedown");
		this.stage.removeAllEventListeners("stagemousemove");
		this.stage.removeAllEventListeners("stagemouseup");

		this.mouseStrategy = this.strategyFactory.getMousStrategy(tool,this);

		this.stage.addEventListener("stagemousedown" , (event) => {this.mouseStrategy.onMousDown(event)});
		this.stage.addEventListener("stagemousemove" , (event) => {this.mouseStrategy.onMouseMove(event)});
		this.stage.addEventListener("stagemouseup" , (event) => {this.mouseStrategy.onMouseUp(event)});
	}

	removeStageEventListeners(){
		if(this.stage != null){
			this.stage.removeAllEventListeners("stagemousedown");
			this.stage.removeAllEventListeners("stagemousemove");
			this.stage.removeAllEventListeners("stagemouseup");
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
			this.stage.addChildAt(newShape,shapeIndex);
		}
		this.stage.update();
	}

	checkString(str:String) : boolean{
		return str!=undefined&&str!=null&&str!="";
	}
}
