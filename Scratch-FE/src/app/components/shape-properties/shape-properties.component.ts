import { Component, OnInit, EventEmitter, Output } from '@angular/core';


@Component({
  selector: 'app-shape-properties',
  templateUrl: './shape-properties.component.html',
  styleUrls: ['./shape-properties.component.scss']
})
export class ShapePropertiesComponent implements OnInit {

  @Output("onDelete")
  deleteEvent : EventEmitter<void>;

  constructor() {
    this.deleteEvent = new EventEmitter();
   }

  ngOnInit() {
  }

  onDelete(){
    this.deleteEvent.emit();
  }
}
