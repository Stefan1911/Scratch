import { Component, OnInit } from '@angular/core';
import { ProjectModel } from 'src/app/models/ProjectModel';
@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: ProjectModel[];
  constructor() {
    var proj=new ProjectModel("Supplemental actions","Supplemental actions are represented by icons, text, and UI controls on cards. They are typically placed at the bottom of the card For more than two supplemental actions, use an overflow menu instead.","https://images.pexels.com/photos/300857/pexels-photo-300857.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");
    this.projects=new Array();
    
    this.projects.push(proj);
    this.projects.push(proj);
    this.projects.push(proj);
    this.projects.push(proj);
    this.projects.push(proj);
   }

  ngOnInit() {
  }

}
