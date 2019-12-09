import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppCanvasComponent } from './drawing-station/app-canvas/app-canvas.component';
import { DrawingStationComponent } from './drawing-station/drawing-station.component';
import { ToolbarComponent } from './drawing-station/toolbar/toolbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTreeModule} from '@angular/material/tree';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { HttpClientModule } from "@angular/common/http";
 
@NgModule({
  declarations: [
    AppComponent,
    AppCanvasComponent,
    DrawingStationComponent,
    ToolbarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTreeModule,
    MatButtonModule,
    MatIconModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
