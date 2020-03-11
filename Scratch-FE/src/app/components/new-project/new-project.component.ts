import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProjectModel } from 'src/app/models/ProjectModel';
import { ProjectService } from 'src/app/services/httpServices/projectService';
import { ProjectsComponent } from 'src/app/pages/projects/projects.component';

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
  constructor(private projectService : ProjectService,public dialogRef: MatDialogRef<NewProjectComponent>) { }
  
  submit(){
    let project : ProjectModel= new ProjectModel(this.name,this.description, this.pictureUrl);
 
    this.projectService.post(project).subscribe((response : ProjectModel) => {
      if(response != null && response != undefined){
        this.project=response;
      }
    });
  }
  ngOnInit() {
  }
  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }
  onNoClick(): void {
    this.dialogRef.close(this.project);
  }
}
