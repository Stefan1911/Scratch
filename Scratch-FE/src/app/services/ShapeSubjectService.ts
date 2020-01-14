import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ShapeModel } from '../models/ShapeModel';
import { Shape } from 'createjs-module';

@Injectable({
	providedIn: 'root'
})
export class ShapeSubjectService{
	shapeCreatedSubject = new Subject<ShapeModel>();
	moveSubject = new Subject<{shapeIndex:number,xMovement:number,yMovement:number}>()
	shapeUpdatedSubject = new Subject<ShapeModel>();
	shapeDeletedSubject = new Subject<ShapeModel>();

	constructor() {
	}
}