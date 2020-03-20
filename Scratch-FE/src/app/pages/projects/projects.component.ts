import { Component, OnInit } from '@angular/core';
import { ProjectModel } from 'src/app/models/ProjectModel';
import { Router } from '@angular/router';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog'; 
import { NewProjectComponent } from 'src/app/components/new-project/new-project.component';
import {ViewEncapsulation} from '@angular/core';
import { ProjectService } from 'src/app/services/httpServices/projectService';
import { UserStore } from 'src/app/services/userStoreService';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DeleteDialogComponent } from 'src/app/components/delete-dialog/delete-dialog.component';
import { JoinProjectComponent } from 'src/app/components/join-project/join-project.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
  encapsulation: ViewEncapsulation.None 
})
export class ProjectsComponent implements OnInit {

  projects: ProjectModel[];

  constructor( private router : Router,public dialog: MatDialog, private userStore : UserStore, private projectService:ProjectService, private _snackBar: MatSnackBar) {
    this.projects=new Array();
    this.projectService.getUserProject(userStore.user.id).subscribe((response : ProjectModel[]) => {
      if(response != null && response != undefined){
       this.projects=response;
      }
    });

   }

   onNewProject(){
    const dialogRef = this.dialog.open(NewProjectComponent, {
      panelClass: 'my-dialog'
    }); 
    dialogRef.afterClosed().subscribe((response : ProjectModel) => {
      if(response!=null || response!=undefined)
        this.projects.push(response);
    });
   }
   
   onDeleteProject(projectId: string){
    const dialogRef = this.dialog.open(DeleteDialogComponent, {    
    }); 
    dialogRef.afterClosed().subscribe((response : boolean) => {
      if(response)
        {
          this.projectService.deleteProject(projectId).subscribe((response : ProjectModel) => {
            if(response != null && response != undefined){
             this.projects.pop().id=projectId;
             this.openSnackBar();
            }
          });
        }
        
    });
   }
  ngOnInit() {}

    open(projectId: string){
      this.router.navigate(["drawingStation/"+projectId]);
    }
   
    openSnackBar() {
      this._snackBar.open("Project deleted","", {
        duration: 2500,
      });
    }
    
    onJoin(){
      const dialogRef = this.dialog.open(JoinProjectComponent, {    
      }); 
      dialogRef.afterClosed().subscribe((projectKey : string) => {
        if(projectKey != null && projectKey != undefined)
          { 
            this.projectService.joinProject(projectKey,this.userStore.user.id).subscribe((response :ProjectModel ) => {
            if(response != null && response != undefined){
                this.projects.push(response);
            }
          });
          }         
      });
    }
}
