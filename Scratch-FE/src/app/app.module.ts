import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatDialogModule} from '@angular/material/dialog';
import { AppComponent } from './app.component';
import { AppCanvasComponent } from './drawing-station/app-canvas/app-canvas.component';
import { DrawingStationComponent } from './drawing-station/drawing-station.component';
import { ToolbarComponent } from './drawing-station/toolbar/toolbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTreeModule} from '@angular/material/tree';
import { MatButtonModule} from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import { HttpClientModule } from "@angular/common/http";
import { MatGridListModule} from '@angular/material/grid-list';
import { MatSidenavModule} from '@angular/material/sidenav';
import { LogInComponent } from './pages/log-in/log-in.component';
import { MatCardModule} from '@angular/material/card';
import { MatTabsModule} from '@angular/material/tabs';
import { MatInputModule} from '@angular/material/input';
import { ProjectsComponent } from './pages/projects/projects.component';
import { MatMenuModule} from '@angular/material/menu';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FirstPageComponent } from './pages/first-page/first-page.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginGuardService} from 'src/app/services/authGuards/loginGuardService'
import { ProfileComponent } from './components/profile/profile.component';
import { NewProjectComponent } from './components/new-project/new-project.component';
import { NewTableDialogComponent } from './components/new-table-dialog/new-table-dialog.component';
import { FormsModule } from '@angular/forms';
import { ChatComponentComponent } from './components/chat-component/chat-component.component';
import { MatListModule } from '@angular/material/list';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';

const appRoutes: Routes = [
  { path: 'home', component: FirstPageComponent },
  { path: 'login', component: LogInComponent },
  { path: 'chat', component: ChatComponentComponent },
  { path: 'drawingStation/:projectId', component: DrawingStationComponent, canActivate:[LoginGuardService]},
  { path: 'profile', component: ProfileComponent },
  { path: 'newProject', component: NewProjectComponent },
  { path: 'projects' , component : ProjectsComponent , canActivate:[LoginGuardService]},
  { path: 'drawingStation', component: DrawingStationComponent, canActivate:[LoginGuardService]},
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    AppCanvasComponent,
    DrawingStationComponent,
    ToolbarComponent,
    LogInComponent,
    ProjectsComponent,
    NavBarComponent,
    FirstPageComponent,
    ProfileComponent,
    ToolbarComponent,
    ToolbarComponent,
    LogInComponent,
    NewProjectComponent,
    NewTableDialogComponent,
    ChatComponentComponent,
    ConfirmComponent,
    DeleteDialogComponent
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
    MatMenuModule,
    MatDialogModule,
    FormsModule,
    MatListModule,
    MatSnackBarModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  entryComponents: [NewTableDialogComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
