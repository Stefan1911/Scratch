import { Injectable } from '@angular/core';
import { DrawRectStrategy } from './DrawRectStrategy';
import { SelectorTool } from './SelectorTool';
import { PencilTool } from './PencilTool';
import { ShapeSubjectService } from '../ShapeSubjectService';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';

@Injectable()
export class MouseStrategyFactory {
    constructor(private shapeSubjects : ShapeSubjectService){}

    getMousStrategy(strategy :MouseStrategyEnum , canvas : AppCanvasComponent){
        let retStrategy:any;
        switch (strategy) {
            case MouseStrategyEnum.drawRect:
                retStrategy = new DrawRectStrategy(canvas);
                break;
            case MouseStrategyEnum.selector:
                retStrategy = new SelectorTool(canvas);
            break;
            case MouseStrategyEnum.pencil:
                //retStrategy = new PencilTool(stage,this.shapeSubjects);
            default:
                break;
        }
        return retStrategy;
	}
    
}



export enum MouseStrategyEnum{
    moveView,
    drawRect,
    selector,
    pencil
}