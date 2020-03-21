import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import * as createjs from 'createjs-module';
import { MouseStrategyFactory, MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';
import { ShapeSubjectService } from 'src/app/services/ShapeSubjectService';
import { ShapeService } from 'src/app/services/httpServices/ShapeService';
import { SignalRResiver } from 'src/app/services/httpServices/signalRReciver';
import { TableService } from 'src/app/services/httpServices/TableService';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { ShapeModel } from 'src/app/models/ShapeModel';
import { PointModel } from 'src/app/models/PointModel';
import { MAT_LABEL_GLOBAL_OPTIONS } from '@angular/material/core';
import { Subscription } from 'rxjs';
import { Drawable } from 'src/app/models/interfaces/initializable';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';

@Component({
  selector: 'app-canvas',
  templateUrl: './app-canvas.component.html',
  styleUrls: ['./app-canvas.component.css'],
  providers: [MouseStrategyFactory]
})
export class AppCanvasComponent implements OnInit {

	mouseStrategy : any;
	stage : createjs.Stage;
	@Input()
	drawingBoardId : string;
	@Input()
	projectId :string;
	drawingBoard : DrawingBoardModel;
	conncionID : string ;
	shapes: Drawable[];
	selectedShape: Drawable = null;

	@Output()
	shapeSelectionChaned: EventEmitter<void>;
  
  constructor(public strategyFactory : MouseStrategyFactory
			,public shapeService: ShapeService
			,public reciver : SignalRResiver 
			,public getService : TableService
			) { 
				this.shapes = new Array();
				this.shapeSelectionChaned = new EventEmitter();
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
				let temp = drawingBoard.shapes.map( (shapeHelper : ShapeHelperModel) => {
					let model = new ShapeModel();
					model.fromShapeHelper(shapeHelper);
					return model;
				})
				console.log(temp);
				
				this.DrawAllShapes(temp);
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

	DrawAllShapes( shapes:Drawable[]){
		this.shapes = new Array();
		shapes.forEach((shape : Drawable) =>{
			shape.tableId = this.drawingBoardId;
			let tempShape = new ShapeModel();
			tempShape.shapeId = shape.shapeId;
			tempShape.shapeIndex = shape.shapeIndex;
			tempShape.tableId = shape.tableId;
			tempShape.points = shape.points;
			tempShape.fillColor = shape.fillColor;
			tempShape.strockColor = shape.strockColor;
			tempShape.type = shape.type;
			this.shapes.push(tempShape);
			this.drawShape(tempShape);
		})

	}

	reDrawAllShapes(){
		this.stage.removeAllChildren()
		this.shapes.forEach( (shape : ShapeModel )=> {
			this.drawShape(shape);
		});
		this.stage.update();
	}

	reDrawShape(shape : Drawable){
		shape.initializeDrowing();
		this.stage.update();
	}
	
	drawShape(shape:Drawable){
		shape.initializeDrowing();
		this.stage.addChild(shape);
		this.stage.update();
	}

	checkString(str:String) : boolean{
		return str!=undefined&&str!=null&&str!="";
	}

	deleteShape(){
		this.shapeService.deleteShape(this.conncionID,this.drawingBoardId,this.selectedShape.shapeId)
		this.deleteShapeWithId(this.selectedShape.shapeId);
	}

	deleteShapeWithId(id: string){
		this.shapes = this.shapes.filter(shape => shape.shapeId != id);
		this.reDrawAllShapes();
		this.selectedShape = null;
	}
}
