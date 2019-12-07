import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {


  @Output("toolChage")
  toolChangerEvent : EventEmitter<MouseStrategyEnum> = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }
  changeTool(tool:MouseStrategyEnum){
    this.toolChangerEvent.emit(tool);
  }
  setSelectorTool(){
    this.changeTool(MouseStrategyEnum.selector);
  }
  setDrawRectTool(){
    this.changeTool(MouseStrategyEnum.drawRect);
  }
}
