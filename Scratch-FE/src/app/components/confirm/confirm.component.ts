import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/services/httpServices/projectService';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.scss']
})
export class ConfirmComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ConfirmComponent>) { }

  ngOnInit() {
  }
  cancel(){
    this.dialogRef.close(false);
  }
  delete(){
    this.dialogRef.close(true);
  }
}
