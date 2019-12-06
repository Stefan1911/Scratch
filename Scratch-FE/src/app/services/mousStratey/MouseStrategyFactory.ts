import { Injectable } from '@angular/core';
import { DrawRectStrategy } from './DrawRectStrategy';

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
            default:
                break;
        }
        return retStrategy;
    }
}



export enum MouseStrategyEnum{
    moveView,
    drawRect
  }