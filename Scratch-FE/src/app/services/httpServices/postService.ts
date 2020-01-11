import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShapeModel } from 'src/app/models/ShapeModel';

const str = '{ "GivenFigure" : null, "PreviousGameState" : null, "NextGameState" : null }';
@Injectable({
	providedIn: 'root'
})
export class PostService{
	constructor(private http : HttpClient ) {
	}

	sendMove(move){
		console.log( move.givenFigure);
		this.http.post("http://localhost:5000/api/GameState",this.transformMove(move))
			.subscribe((response) => {
				console.log(response);
			});
	}

	private transformMove(move){
		move.previousGameState.gameBoard.forEach(row => {
			while (row.length < 4) {
				row.push(null);
			}
		});

		move.nextGameState.gameBoard.forEach(row => {
			while (row.length < 4) {
				row.push(null);
			}
		});
		return move;
	}

	sendShape(shape : ShapeModel){
		console.log("shape has been send");
		this.http.post("http://localhost:5000/api/Shape",shape)
			.subscribe( (response) => {
				console.log(response);
			})
	}
}