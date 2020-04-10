import { Injectable } from '@angular/core';
import { TwoPointTool } from '../TwoPointTool';
import { SelectorTool } from '../SelectorTool';
import { MultiPointTool } from '../MultiPointTool';
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
                retStrategy = new TwoPointTool(canvas,ShapeNames.Rectangle,this.shapeFactory);
                break;
            case MouseStrategyEnum.drawCircle:
                retStrategy = new TwoPointTool(canvas,ShapeNames.Circle,this.shapeFactory);
                break;
            case MouseStrategyEnum.drawLien:
                retStrategy = new TwoPointTool(canvas,ShapeNames.Line,this.shapeFactory);
                break;
            case MouseStrategyEnum.selector:
                retStrategy = new SelectorTool(canvas);
                break;
            case MouseStrategyEnum.drawMultiLine:
                retStrategy = new MultiPointTool(canvas,ShapeNames.multiLine,this.shapeFactory);
                break;
            case MouseStrategyEnum.drawPolygon:
                retStrategy = new MultiPointTool(canvas,ShapeNames.polygon,this.shapeFactory);
                break;
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
    drawMultiLine,
    drawPolygon,
    selector
}