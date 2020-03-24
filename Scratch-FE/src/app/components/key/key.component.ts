import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from 'src/app/pages/projects/projects.component';

@Component({
  selector: 'app-key',
  templateUrl: './key.component.html',
  styleUrls: ['./key.component.scss']
})

export class KeyComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<KeyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData ) {
      
     }

  key:string;
  ngOnInit() {
  }
  ok(){
    this.dialogRef.close();
  }

}
