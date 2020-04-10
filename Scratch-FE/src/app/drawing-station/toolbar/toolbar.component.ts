import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {NestedTreeControl} from '@angular/cdk/tree';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import { MouseStrategyEnum } from 'src/app/services/mousStratey/Factories/MouseStrategyFactory';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

export interface Tile {
  toolName? : MouseStrategyEnum;
  iconName: string;
  toolTipText?:string
}

interface treeNode {
  dispalyText?: string;
  children?: treeNode[];
  tiles?: Tile[]
  
}


const TREE_DATA: treeNode[] = [
  {
    dispalyText: 'basic tools',
    children: [
      {
        tiles : [
          {toolName : MouseStrategyEnum.drawRect,iconName : "rectangle"},
          { toolName:MouseStrategyEnum.selector ,iconName : "move-arrows"},
          { toolName:MouseStrategyEnum.drawCircle ,iconName : "circle"},
          { toolName : MouseStrategyEnum.drawPolygon,iconName : "polygon"},
        ]
      }
    ]
  }, {
    dispalyText: 'Lines',
     children: [
     {
        tiles: [
          { toolName : MouseStrategyEnum.drawLien,iconName : "line"},
          { toolName : MouseStrategyEnum.drawMultiLine,iconName : "multi-line",},
        ]
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



  treeControl = new NestedTreeControl<treeNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<treeNode>();

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    this.dataSource.data = TREE_DATA;

    iconRegistry.addSvgIcon(
      'rectangle',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/vector.svg'));
    iconRegistry.addSvgIcon(
      'move-arrows',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/move-arrows.svg'));
    iconRegistry.addSvgIcon(
      'circle',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/circle.svg'));
    iconRegistry.addSvgIcon(
        'line',
        sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/line.svg'));
    iconRegistry.addSvgIcon(
        'multi-line',
        sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/multyPointLine.svg'));
    iconRegistry.addSvgIcon(
        'polygon',
        sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/distort.svg'));
    iconRegistry.addSvgIcon(
      'Coming soon...',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/fav-icons/not-found.svg'));

    
  }
  
  hasChild = (_: number, node: treeNode) => !!node.children && node.children.length > 0;

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
    
  }
}
