import { Component, OnInit, Inject, ViewChild, ComponentRef } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProjectModel } from 'src/app/models/ProjectModel';
import { ProjectService } from 'src/app/services/httpServices/projectService';
import { PictureService } from 'src/app/services/httpServices/pictureService';
import { ProjectsComponent } from 'src/app/pages/projects/projects.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserStore } from 'src/app/services/userStoreService';
import { DrawingBoardModel } from 'src/app/models/DrawingBoardModel';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {
  imageURL : string = "https://res.cloudinary.com/scratchimagestore/image/upload/v1585646132/samples/animals/kitten-playing.gif";
  name:string;
  pictureUrl:string;
  description:string;
  table:string;
  project:ProjectModel;
  selectedFile: File
  uploadingFile : boolean = false;
  constructor(private pictureService : PictureService, private projectService : ProjectService,private userStore : UserStore,public dialogRef: MatDialogRef<NewProjectComponent>, private _snackBar: MatSnackBar) { }

  onFileChanged(event) {
    this.uploadingFile = true;
    this.selectedFile = event.target.files[0];
    this.pictureService.uploadImage(this.selectedFile)
      .subscribe( (response : {imageId:string}) => {
        this.imageURL = response.imageId;
        this.uploadingFile = false
      })
  }

  submit(){
    let project : ProjectModel= new ProjectModel(this.name,this.description, this.pictureUrl);
    project.drawingBoards = new Array()
    let newTable = new DrawingBoardModel();
    newTable.name = this.table;
    project.drawingBoards.push(newTable);
    project.userIDs= new Array();
    project.userIDs.push(this.userStore.user.id);
    project.pictureUrl=this.imageURL;
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
