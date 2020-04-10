import { Component, OnInit, Input, EventEmitter, Output, ViewChild, ElementRef } from '@angular/core';
import * as createjs from 'createjs-module';
import { MouseStrategyFactory, MouseStrategyEnum } from 'src/app/services/mousStratey/Factories/MouseStrategyFactory';
import { ShapeService } from 'src/app/services/httpServices/ShapeService';
import { SignalRResiver } from 'src/app/services/httpServices/signalRReciver';
import { TableService } from 'src/app/services/httpServices/TableService';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { Drawable, ShapeNames } from 'src/app/models/interfaces/Drawable';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { ShapeFactory } from 'src/app/services/mousStratey/Factories/ShapeFactory';

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
  
  constructor(public strategyFactory : MouseStrategyFactory,
			public shapeService: ShapeService,
			public reciver : SignalRResiver,
			public getService : TableService,
			public shapeFactory : ShapeFactory
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
					let model = this.shapeFactory.getShape(ShapeNames[shapeHelper.type]);
					model.fromShapeHelper(shapeHelper,this.drawingBoardId);
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
		this.stage.removeAllChildren();
		this.shapes = new Array();
		shapes.forEach((shape : Drawable) =>{
			shape.tableId = this.drawingBoardId;
			this.shapes.push(shape);
			this.drawShape(shape);
		})

	}

	reDrawAllShapes(){
		this.stage.removeAllChildren()
		this.shapes.forEach( (shape : Drawable )=> {
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

	chageShapeColor(color : string, isFill:boolean){
		if(isFill){
			this.selectedShape.fillColor = color;
		}
		else{
			this.selectedShape.strockColor = color
		}
		this.reDrawAllShapes();
		this.shapeService.updateShape(this.conncionID,this.selectedShape);
	}

	saveShape(newShape : Drawable){
		newShape.tableId = this.drawingBoardId;
		this.shapeService.sendShape(this.conncionID,newShape)
                .subscribe( (shape : ShapeHelperModel) => {					
                    newShape.shapeId = shape.id;
                })
	}

}
