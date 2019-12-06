import { Component, OnInit } from '@angular/core';
import * as createjs from 'createjs-module';
import { MouseStrategyFactory, MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';

@Component({
  selector: 'app-canvas',
  templateUrl: './app-canvas.component.html',
  styleUrls: ['./app-canvas.component.css'],
  providers: [MouseStrategyFactory]
})
export class AppCanvasComponent implements OnInit {

  mouseStrategy : any;
  constructor(private strategyFactory : MouseStrategyFactory) { }

  ngOnInit() {
    var stage = new createjs.Stage("demoCanvas");
    this.mouseStrategy = this.strategyFactory.getMousStrategy(MouseStrategyEnum.drawRect,stage);
    
    
    stage.addEventListener("stagemousedown" , (event) => {this.mouseStrategy.onMousDown(event)});
    stage.addEventListener("stagemousemove" , (event) => {this.mouseStrategy.onMouseMove(event)});
    stage.addEventListener("stagemouseup" , (event) => {this.mouseStrategy.onMouseUp(event)});
    var circle = new createjs.Shape();
    circle.graphics.beginFill("DeepSkyBlue").drawCircle(0, 0, 50);
    circle.x = 100;
    circle.y = 100;
    //circle.addEventListener("click" , (event) => {this.mouseStrategy.onMousDown(event)});
    stage.addChild(circle);
 
    stage.update();
 
    // createjs.Tween.get(circle, { loop: true })
    // .to({ x: 400 }, 1000, createjs.Ease.getPowInOut(4))
    // .to({ alpha: 0, y: 175 }, 500, createjs.Ease.getPowInOut(2))
    // .to({ alpha: 0, y: 225 }, 100)
    // .to({ alpha: 1, y: 200 }, 500, createjs.Ease.getPowInOut(2))
    // .to({ x: 100 }, 800, createjs.Ease.getPowInOut(2));
 
    // createjs.Ticker.setFPS(60);
    // createjs.Ticker.addEventListener("tick", stage);

  }

}
