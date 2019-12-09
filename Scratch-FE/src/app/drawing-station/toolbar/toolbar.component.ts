import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {NestedTreeControl} from '@angular/cdk/tree';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import { MouseStrategyEnum } from 'src/app/services/mousStratey/MouseStrategyFactory';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';


interface FoodNode {
  name: string;
  toolName? : MouseStrategyEnum;
  iconLink?: string
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'basic tools',
    children: [
      {name: 'rectangle' , toolName : MouseStrategyEnum.drawRect,iconLink : "https://www.freepik.com/free-icon/move-arrows_887578.htm#page=1&query=move&position=0"},
      {name: 'move' , toolName:MouseStrategyEnum.selector ,iconLink :"https://www.freepik.com/free-icon/move-arrows_887578.htm#page=1&query=move&position=0"},
    ]
  }, {
    name: 'UML Diagrams',
    iconLink:'',
     children: [
     {
        name: 'Coming soon...',
        toolName : MouseStrategyEnum.moveView,
        iconLink: 'https://www.freepik.com/free-icon/move-arrows_887578.htm#page=1&query=move&position=0'
      }
    ]
  },
];

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    this.dataSource.data = TREE_DATA;
    iconRegistry.addSvgIcon(
      'rectangle',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/vector.svg'));
    iconRegistry.addSvgIcon(
      'move',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/move-arrows.svg'));
    iconRegistry.addSvgIcon(
      'Coming soon...',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/not-found.svg'));
  }

  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  @Output("toolChage")
  toolChangerEvent : EventEmitter<MouseStrategyEnum> = new EventEmitter();
  ngOnInit() {
  }
  changeTool(tool:MouseStrategyEnum){
    this.toolChangerEvent.emit(tool);
  }
  setSelectorTool(){
    this.changeTool(MouseStrategyEnum.selector);
  }
  setDrawRectTool(){
    this.changeTool(MouseStrategyEnum.drawRect);
  }
  someHandler(param){
    console.log(param);
    
  }
}
