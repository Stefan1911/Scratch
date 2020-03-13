import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { LogInComponent } from 'src/app/pages/log-in/log-in.component';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { ThrowStmt } from '@angular/compiler';
import { promise } from 'protractor';
import { DrawingStationComponent } from 'src/app/drawing-station/drawing-station.component';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { ShapeModel } from 'src/app/models/ShapeModel';

@Injectable({
	providedIn: 'root'
})
export class SignalRResiver {

	private hubConnection: signalR.HubConnection
	private connetionURL : string
	private id:string
	private promis;
	constructor() {		
		this.hubConnection = new signalR.HubConnectionBuilder()
			.withUrl('http://localhost:5000/DrawingBoard')
			.build();
		this.promis= this.hubConnection
			.start()
			.then( () =>{
				this.connetionURL = this.hubConnection["connection"].transport.webSocket.url
				let r = /.*\=(.*)/;
				return r.exec(this.connetionURL)[1]
			}).then((id) =>{
				let localId = id;
				return localId
			})
			.catch(err => console.log('Error while starting connection: ' + err))
	}

	async registerDrawingStation(drawingStatino : DrawingStationComponent): Promise<string>{
		this.hubConnection.off(drawingStatino.Project.id+"/add");
		this.hubConnection.on(drawingStatino.Project.id+"/add",(drawingBoard: DrawingBoardModel)=>{
			drawingStatino.drawingBoards.push(drawingBoard);
		})
		let id = await this.promis;
		return id;
	}
	
	async registerCanvas(canvas :AppCanvasComponent): Promise<string>{
		this.removeAllHubs(canvas)
		this.hubConnection.on(canvas.drawingBoardId, (shape : ShapeHelperModel) => {
			let newShape = new ShapeModel();
			newShape.fromShapeHelper(shape);
			newShape.tableId = canvas.drawingBoardId;
			canvas.shapes.push(newShape);
			canvas.drawShape(newShape);
			});
		this.hubConnection.on(canvas.drawingBoardId + "/updateShape", (shape : ShapeHelperModel, shapeIndex) =>{
			canvas.shapes[shapeIndex].fromShapeHelper(shape);
			canvas.reDrawShape(canvas.shapes[shapeIndex]);
		})
		let id = await this.promis;
		return id;
	}

	removeAllHubs(canvas :AppCanvasComponent){
		this.hubConnection.off(canvas.drawingBoardId);
		this.hubConnection.off(canvas.drawingBoardId + "/updateShape");
	}

}