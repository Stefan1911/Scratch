import { Component } from '@angular/core';
import { ShapeService } from './services/httpServices/ShapeService';
import { ShapeSubjectService } from './services/ShapeSubjectService';
import { Shape } from 'createjs-module';
import { ShapeModel } from './models/ShapeModel';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Scratch';
  /**
   *
   */
  constructor(private titleService: Title) {
    this.titleService.setTitle(this.title);
  }
}
