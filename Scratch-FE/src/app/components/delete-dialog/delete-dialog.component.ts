import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DeleteOrLeave } from 'src/app/drawing-station/drawing-station.component';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.scss']
})
export class DeleteDialogComponent implements OnInit {

  private leave:boolean;
  constructor(public dialogRef: MatDialogRef<DeleteDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: DeleteOrLeave) { 
    this.leave=data.leave;
  }

  ngOnInit() {
   }
   cancel(){
     this.dialogRef.close(false);
   }
   delete(){
     this.dialogRef.close(true);
  }
}
