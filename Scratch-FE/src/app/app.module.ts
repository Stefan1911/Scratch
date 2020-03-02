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
<<<<<<< HEAD
import { ProjectsComponent } from './pages/projects/projects.component';
import {MatMenuModule} from '@angular/material/menu';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FirstPageComponent } from './pages/first-page/first-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
=======
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const appRoutes: Routes = [
  { path: 'login', component: LogInComponent },
  { path: 'notfount', component: NotFoundComponent },
  { path: '**', redirectTo: '/login', pathMatch: 'full' }
];

>>>>>>> feat angulare routing
@NgModule({
  declarations: [
    AppComponent,
    AppCanvasComponent,
    DrawingStationComponent,
<<<<<<< HEAD
    ToolbarComponent,
    LogInComponent,
    ProjectsComponent,
    NavBarComponent,
    FirstPageComponent,
    ProfilePageComponent
=======
    ToolbarComponent,NotFoundComponent,
    LogInComponent
>>>>>>> feat angulare routing
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
<<<<<<< HEAD
    MatToolbarModule,
    MatMenuModule

=======
    RouterModule.forRoot(
      appRoutes
    )
>>>>>>> feat angulare routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
