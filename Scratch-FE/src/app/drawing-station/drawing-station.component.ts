import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseStrategyFactory, MouseStrategyEnum } from '../services/mousStratey/MouseStrategyFactory';

@Component({
  selector: 'app-drawing-station',
  templateUrl: './drawing-station.component.html',
  styleUrls: ['./drawing-station.component.css'],
})
export class DrawingStationComponent implements OnInit {
  @ViewChild("canvas", {static: false})
  drawignBoard;

  constructor() {
   }

  ngOnInit() {
  }

  onToolChange(tool){
    this.drawignBoard.setTool(tool);
  }

}

