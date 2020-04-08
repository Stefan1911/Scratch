import { Injectable } from '@angular/core';
import { DrawRectStrategy } from '../DrawRectStrategy';
import { SelectorTool } from '../SelectorTool';
import { PencilTool } from '../PencilTool';
import { AppCanvasComponent } from 'src/app/drawing-station/app-canvas/app-canvas.component';
import { ShapeFactory } from './ShapeFactory';
import { ShapeNames } from 'src/app/models/interfaces/Drawable';

@Injectable()
export class MouseStrategyFactory {
    constructor(private shapeFactory: ShapeFactory){}

    getMousStrategy(strategy :MouseStrategyEnum , canvas : AppCanvasComponent){
        let retStrategy:any;
        switch (strategy) {
            case MouseStrategyEnum.drawRect:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames.Rectangle,this.shapeFactory);
                break;
            case MouseStrategyEnum.drawCircle:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames.Circle,this.shapeFactory);
                break;
            case MouseStrategyEnum.drawLien:
                retStrategy = new DrawRectStrategy(canvas,ShapeNames.Line,this.shapeFactory);
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