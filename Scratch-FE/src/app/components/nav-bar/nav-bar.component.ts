import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  name: string;
  pictureUrl: string;
  constructor() {
    this.name="Minja";
    this.pictureUrl="https://images.pexels.com/photos/300857/pexels-photo-300857.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940";
   }

  ngOnInit() {
  }

}
