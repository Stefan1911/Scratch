import { Injectable } from '@angular/core';
import { DrawRectStrategy } from './DrawRectStrategy';
import { SelectorTool } from './SelectorTool';
import { PencilTool } from './PencilTool';
import { ShapeSubjectService } from '../ShapeSubjectService';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { ShapeNames } from 'src/app/models/ShapeModel';

@Injectable()
export class MouseStrategyFactory {
    constructor(private shapeSubjects : ShapeSubjectService){}

    getMousStrategy(strategy :MouseStrategyEnum , canvas : AppCanvasComponent){
        let retStrategy:any;
        switch (strategy) {
            case MouseStrategyEnum.drawRect:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames[ShapeNames.Rectangle]);
                break;
            case MouseStrategyEnum.drawCircle:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames[ShapeNames.Circle]);
                break;
            case MouseStrategyEnum.drawLien:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames[ShapeNames.Line]);
                break;
            case MouseStrategyEnum.selector:
                retStrategy = new SelectorTool(canvas);
            break;
                break;
        }
        return retStrategy;
	}
    
}



export enum MouseStrategyEnum{
    moveView,
    drawRect,
    drawCircle,
    drawLien,
    selector,
}