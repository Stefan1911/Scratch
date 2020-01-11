import { Injectable } from '@angular/core';
import { DrawRectStrategy } from './DrawRectStrategy';
import { SelectorTool } from './SelectorTool';
import { PencilTool } from './PencilTool';
import { ShapeSubjectService } from '../ShapeSubjectService';

@Injectable()
export class MouseStrategyFactory {
    constructor(private shapeSubjects : ShapeSubjectService){}

    getMousStrategy(strategy :MouseStrategyEnum , stage:createjs.Stage){
        let retStrategy:any;
        switch (strategy) {
            case MouseStrategyEnum.drawRect:
                retStrategy = new DrawRectStrategy(stage,this.shapeSubjects);
                break;
            case MouseStrategyEnum.selector:
                retStrategy = new SelectorTool(stage,this.shapeSubjects);
            break;
            case MouseStrategyEnum.pencil:
                retStrategy = new PencilTool(stage,this.shapeSubjects);
            default:
                break;
        }
        return retStrategy;
	}
	
	setShapeSubject(subject : ShapeSubjectService){
		this.shapeSubjects = subject
	}
}



export enum MouseStrategyEnum{
    moveView,
    drawRect,
    selector,
    pencil
}