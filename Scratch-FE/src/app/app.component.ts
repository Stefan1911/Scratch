import { Component } from '@angular/core';
import { PostService } from './services/httpServices/postService';
import { ShapeSubjectService } from './services/ShapeSubjectService';
import { Shape } from 'createjs-module';
import { ShapeModel } from './models/ShapeModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Scratch-FE';
  /**
   *
   */
  constructor() {
  }
}
