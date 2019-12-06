import { Component, OnInit } from '@angular/core';
import { MouseStrategyFactory, MouseStrategyEnum } from '../services/mousStratey/MouseStrategyFactory';

@Component({
  selector: 'app-drawing-station',
  templateUrl: './drawing-station.component.html',
  styleUrls: ['./drawing-station.component.css'],
})
export class DrawingStationComponent implements OnInit {

  MouseStrategy :MouseStrategyEnum;
  constructor() {
    this.MouseStrategy = MouseStrategyEnum.moveView;
   }

  ngOnInit() {
   
  }

}

