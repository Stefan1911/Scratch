import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {
  name:string;
  pictureUrl:string;
  description:string;

  constructor() { }

  ngOnInit() {
  }
  showPicture(){
    if(this.pictureUrl=="" || this.pictureUrl==null || this.pictureUrl==undefined)
      return false;
    return true;
  }
}
