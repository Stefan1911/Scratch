import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';

@Injectable({
	providedIn: 'root'
})
export class SignalRResiver {

	private hubConnection: signalR.HubConnection

	constructor() {
		this.hubConnection = new signalR.HubConnectionBuilder()
			.withUrl('http://localhost:5000/DrawingBoard')
			.build();
		this.hubConnection
			.start()
			.catch(err => console.log('Error while starting connection: ' + err))
	}
	
	registerDrawingStation(canvas :AppCanvasComponent){
		this.hubConnection.on(canvas.drawingBoardId, (data) => {
			console.log({message : "stiglo netso od backenda", data: data});
		  });
	}

}