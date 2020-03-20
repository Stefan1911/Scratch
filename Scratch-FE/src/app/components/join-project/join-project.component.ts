import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-join-project',
  templateUrl: './join-project.component.html',
  styleUrls: ['./join-project.component.scss']
})
export class JoinProjectComponent implements OnInit {

  projectId:string;

  constructor(public dialogRef: MatDialogRef<JoinProjectComponent>) { }

  ngOnInit() {
  }
  cancel(){
    this.dialogRef.close();
  }
  onJoin(){
    this.dialogRef.close(this.projectId);
  }
}
