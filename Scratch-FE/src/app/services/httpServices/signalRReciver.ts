import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';

@Injectable({
	providedIn: 'root'
})
export class SignalRResiver {

	private hubConnection: signalR.HubConnection
	private connetionURL : string
	private id:string
	private promis;
	constructor() {
		console.log("construktor se moziva");
		
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
	
	async registerDrawingStation(canvas :AppCanvasComponent): Promise<string>{
		this.hubConnection.on(canvas.drawingBoardId, (data) => {
			canvas.drawShape(data);
			});
		let id = await this.promis;
		//let r = /.*\=(.*)/;
		//let connectionId = r.exec(this.connetionURL)[1]
		return id;
	}

}