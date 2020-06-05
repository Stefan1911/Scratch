import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { LogInComponent } from 'src/app/pages/log-in/log-in.component';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';
import { DrawingStationComponent } from 'src/app/drawing-station/drawing-station.component';
import { ShapeHelperModel } from 'src/app/models/HelperModels/shapeHelperModel';
import { ChatComponentComponent } from 'src/app/components/chat-component/chat-component.component';
import { ShapeFactory } from '../mousStratey/Factories/ShapeFactory';
import { ShapeNames } from 'src/app/models/interfaces/Drawable';

@Injectable({
	providedIn: 'root'
})
export class SignalRResiver {

	private hubConnection: signalR.HubConnection
	private hubConnectionChat: signalR.HubConnection
	private connetionURL : string
	private id:string
	private promis;
	constructor(private shapeFactory : ShapeFactory) {		
		this.hubConnection = new signalR.HubConnectionBuilder()
			.withUrl('http://localhost:5000/DrawingBoard')
			.build();
		this.hubConnectionChat = new signalR.HubConnectionBuilder()
			.withUrl('http://localhost:5000/Chat')
			.build();
		this.hubConnectionChat.start();
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
		this.hubConnection.off(drawingStatino.Project.id+"/rename");
		this.hubConnection.off(drawingStatino.Project.id+"/delete");
		this.hubConnection.on(drawingStatino.Project.id+"/add",(drawingBoard: DrawingBoardModel)=>{
			drawingStatino.drawingBoards.push(drawingBoard);
		})
		this.hubConnection.on(drawingStatino.Project.id+"/rename",(model: {name, tableId})=>{
			drawingStatino.drawingBoards.find(item=>item.id===model.tableId).name=model.name;
		})
		this.hubConnection.on(drawingStatino.Project.id+"/delete",(drawingBoardId: String)=>{
			drawingStatino.drawingBoards = drawingStatino.drawingBoards.filter(item => item.id !== drawingBoardId);
		})
		let id = await this.promis;
		return id;
	}
	async registerChat(chat:ChatComponentComponent){
		this.hubConnectionChat.on(chat.boardId+"/chat/add",(message )=>{
			chat.chat.messages.push(message);
		})
	}
	async removeChat(chat:ChatComponentComponent){
		this.hubConnectionChat.off(chat.boardId+"/chat/add");
	}
	async registerCanvas(canvas :AppCanvasComponent): Promise<string>{
		this.removeAllCanvasHubs(canvas)
		this.hubConnection.on(canvas.drawingBoardId, (shape : ShapeHelperModel) => {
			let newShape = this.shapeFactory.getShape(ShapeNames[shape.type]);
			newShape.fromShapeHelper(shape,canvas.drawingBoardId);
			newShape.tableId = canvas.drawingBoardId;
			canvas.shapes.push(newShape);
			canvas.drawShape(newShape);
			});
		this.hubConnection.on(canvas.drawingBoardId + "/updateShape", (shape : ShapeHelperModel, shapeIndex) =>{
			let foundShape = canvas.shapes.find( _shape => _shape.shapeId === shape.id);
			foundShape.fromShapeHelper(shape,canvas.drawingBoardId);
			canvas.reDrawShape(foundShape);
		})
		this.hubConnection.on(canvas.drawingBoardId+"/deleteShape",(shapeId : string) =>{
			canvas.deleteShapeWithId(shapeId);
		})
		let id = await this.promis;
		return id;
	}

	removeAllCanvasHubs(canvas :AppCanvasComponent){
		this.hubConnection.off(canvas.drawingBoardId);
		this.hubConnection.off(canvas.drawingBoardId + "/updateShape");
		this.hubConnection.off(canvas.drawingBoardId+"/deleteShape")
	}

}