import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-new-table-dialog',
  templateUrl: './new-table-dialog.component.html',
  styleUrls: ['./new-table-dialog.component.scss']
})
export class NewTableDialogComponent implements OnInit {
  ngOnInit() {
  }

  private tableName :string;
  constructor(
    public dialogRef: MatDialogRef<NewTableDialogComponent>) {}

  onCancel(): void {
    this.dialogRef.close(null);
  }
  onOk() :void{
    let response= (this.tableName == undefined || this.tableName == "")?null:this.tableName;
    this.dialogRef.close(response);
  }
}
