import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProjectModel } from 'src/app/models/ProjectModel';
import { ProjectService } from 'src/app/services/httpServices/projectService';
import { ProjectsComponent } from 'src/app/pages/projects/projects.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserStore } from 'src/app/services/userStoreService';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {
  name:string;
  pictureUrl:string;
  description:string;
  project:ProjectModel;
  constructor(private projectService : ProjectService,private userStore : UserStore,public dialogRef: MatDialogRef<NewProjectComponent>, private _snackBar: MatSnackBar) { }
  
  submit(){
    let project : ProjectModel= new ProjectModel(this.name,this.description, this.pictureUrl);
    project.userIDs= new Array();
    project.userIDs.push(this.userStore.user.id);
    project.pictureUrl="https://pateserv.com/images/projects/project.jpg";
    if(project.name!=null || project.name!=undefined){
      this.projectService.post(project).subscribe((response : ProjectModel) => {
        if(response != null && response != undefined){
          this.project=response;
          this.dialogRef.close(response);
        }
      });
    }
    else{
        this.openSnackBar();
    }  
    
  }
  ngOnInit() { }

  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  openSnackBar() {
    this._snackBar.open("Project must have a name!","", {
      duration: 2500,
    });
  }
}
