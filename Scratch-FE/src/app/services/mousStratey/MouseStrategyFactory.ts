import { Injectable } from '@angular/core';
import { DrawRectStrategy } from './DrawRectStrategy';
import { SelectorTool } from './SelectorTool';

@Injectable()
export class MouseStrategyFactory {
    constructor(){}

    getMousStrategy(strategy :MouseStrategyEnum , stage:createjs.Stage){
        let retStrategy:any;
        switch (strategy) {
            case MouseStrategyEnum.drawRect:
                retStrategy = new DrawRectStrategy(stage);
                break;
            case MouseStrategyEnum.moveView:
                break;
            case MouseStrategyEnum.selector:
                retStrategy = new SelectorTool(stage);
            break;
            default:
                break;
        }
        return retStrategy;
    }
}



export enum MouseStrategyEnum{
    moveView,
    drawRect,
    selector
  }