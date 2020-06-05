import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddNameOrRename } from 'src/app/drawing-station/drawing-station.component';

@Component({
  selector: 'app-new-table-dialog',
  templateUrl: './new-table-dialog.component.html',
  styleUrls: ['./new-table-dialog.component.scss']
})
export class NewTableDialogComponent implements OnInit {
  ngOnInit() {
  }

  private tableName :string;
  private rename:boolean;

  constructor( public dialogRef: MatDialogRef<NewTableDialogComponent> , @Inject(MAT_DIALOG_DATA) public data: AddNameOrRename ) {
      this.rename=data.rename;
  }

  onCancel(): void {
    this.dialogRef.close(null);
  }
  onOk() :void{
    let response= (this.tableName == undefined || this.tableName == "")?null:this.tableName;
    this.dialogRef.close(response);
  }
}
