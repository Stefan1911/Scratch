import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';


@Component({
  selector: 'app-shape-properties',
  templateUrl: './shape-properties.component.html',
  styleUrls: ['./shape-properties.component.scss']
})
export class ShapePropertiesComponent implements OnInit {

  @Input("currentFillColor")
  currentFillColor : string;
  currentStrockColor :string;
  isFillColor : boolean

  @Output("onDelete")
  deleteEvent : EventEmitter<void>;
  @Output("onColorChange")
  coloreChanged : EventEmitter<{color : string, isFill:boolean}>

  public colors :string[];

  constructor() {
    this.isFillColor = true;
    this.deleteEvent = new EventEmitter();
    this.coloreChanged = new EventEmitter();
    this.colors = new Array();
    this.colors.push("#400201");
    this.colors.push("#9e0603");
    this.colors.push("#f73531");
    this.colors.push("#0a2b00")
    this.colors.push("#218f00")
    this.colors.push("#3bff00")
    this.colors.push("#00004d")
    this.colors.push("#0202a3")
    this.colors.push("#0000ff")
    this.colors.push("#000000")
    this.colors.push("#ffffff")
   }

  ngOnInit() {
  }

  onDelete(){
    this.deleteEvent.emit();
  }

  onColorChange(color : string){
    let isFill = this.isFillColor;
    this.changeButtonColor(color);
    this.coloreChanged.emit({color,isFill});
  }

  changeButtonColor(color : string){
    if(this.isFillColor)
      this.currentFillColor = color;
    else
      this.currentStrockColor = color
  }
}
