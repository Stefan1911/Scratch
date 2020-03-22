import { Component, OnInit, EventEmitter, Output } from '@angular/core';


@Component({
  selector: 'app-shape-properties',
  templateUrl: './shape-properties.component.html',
  styleUrls: ['./shape-properties.component.scss']
})
export class ShapePropertiesComponent implements OnInit {

  @Output("onDelete")
  deleteEvent : EventEmitter<void>;
  @Output("onColorChange")
  coloreChanged : EventEmitter<{color : string, isFill:boolean}>

  constructor() {
    this.deleteEvent = new EventEmitter();
    this.coloreChanged = new EventEmitter();
   }

  ngOnInit() {
  }

  onDelete(){
    this.deleteEvent.emit();
  }

  onColorChange(color : string = "#059e19" , isFill : boolean = true){
    this.coloreChanged.emit({color,isFill});
  }
}
