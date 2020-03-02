import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import { AppComponent } from './app.component';
import { AppCanvasComponent } from './drawing-station/app-canvas/app-canvas.component';
import { DrawingStationComponent } from './drawing-station/drawing-station.component';
import { ToolbarComponent } from './drawing-station/toolbar/toolbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTreeModule} from '@angular/material/tree';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { HttpClientModule } from "@angular/common/http";
import {MatGridListModule} from '@angular/material/grid-list';
import {MatSidenavModule} from '@angular/material/sidenav';
import { LogInComponent } from './pages/log-in/log-in.component';
import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import { ProjectsComponent } from './pages/projects/projects.component';
import {MatMenuModule} from '@angular/material/menu';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
@NgModule({
  declarations: [
    AppComponent,
    AppCanvasComponent,
    DrawingStationComponent,
    ToolbarComponent,
    LogInComponent,
    ProjectsComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTreeModule,
    MatButtonModule,
    MatIconModule,
    HttpClientModule,
    MatGridListModule,
    MatSidenavModule,
    MatCardModule,
    MatTabsModule,
    MatInputModule,
    MatToolbarModule,
    MatMenuModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
