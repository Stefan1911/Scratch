import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MouseStrategyFactory, MouseStrategyEnum } from '../services/mousStratey/Factories/MouseStrategyFactory';
import { ProjectModel } from '../models/ProjectModel';
import { DrawingBoardModel } from '../models/DrawingBoardModel';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from '../services/httpServices/projectService';
import { AppCanvasComponent } from './app-canvas/app-canvas.component';
import { MatDialog } from '@angular/material/dialog';
import { NewTableDialogComponent } from '../components/new-table-dialog/new-table-dialog.component';
import { SignalRResiver } from '../services/httpServices/signalRReciver';
import { ChatComponentComponent } from '../components/chat-component/chat-component.component';
import { FormControl } from '@angular/forms';
import { MatTab } from '@angular/material/tabs';
import { ShapePropertiesComponent } from '../components/shape-properties/shape-properties.component';
import { TableService } from '../services/httpServices/TableService';
import { DeleteDialogComponent } from '../components/delete-dialog/delete-dialog.component';

export interface AddNameOrRename {
  rename: boolean;
}
export interface DeleteOrLeave {
  leave: boolean;
}
@Component({
  selector: 'app-drawing-station',
  templateUrl: './drawing-station.component.html',
  styleUrls: ['./drawing-station.component.css'],
})
export class DrawingStationComponent implements OnInit {
  @ViewChild("canvas", {static: false})
  drawignBoard : AppCanvasComponent;
  @ViewChild("chat", {static: false})
  chat : ChatComponentComponent;
  @ViewChild("shapeProperties", {static:false})
  shapeProperties : ShapePropertiesComponent;
  @ViewChild("shapeTab", {static: false})
  shapeTab : MatTab

  Project : ProjectModel;
  selectedBoardId: string;
  showChat:boolean;
  selectedTabNumber:FormControl = new FormControl(0);

  connectionID:string
  public drawingBoards : DrawingBoardModel[];
  constructor(private router : ActivatedRoute,private projectService : ProjectService,private tableService : TableService,public dialog: MatDialog, public reciver : SignalRResiver) {
    this.showChat=false;
    let projectId = this.router.snapshot.params["projectId"]; 
    this.projectService.getProject(projectId).subscribe((Response : any)=>{  
      this.Project = Response;
      this.drawingBoards = Response.drawingBoards;
      this.selectedBoardId = this.drawingBoards[0].id;
      this.drawignBoard.projectId = projectId 
      this.drawignBoard.initShapes(this.selectedBoardId);  
      this.chat.boardId=this.selectedBoardId;    
      this.chat.chatInit(this.selectedBoardId);
      this.reciver.registerDrawingStation(this).then( (mightBeTheId) =>{
        this.connectionID = mightBeTheId
      });
    })

   }

   visibleChat(){
     this.showChat=!this.showChat;
   }
  ngOnInit() { }

  onToolChange(tool){
    this.drawignBoard.setTool(tool);
  }

  onBoardChange(boardId :string){
    this.reciver.removeAllCanvasHubs(this.drawignBoard);
    this.reciver.removeChat(this.chat);
    this.selectedBoardId = boardId;
    this.drawignBoard.initShapes(boardId);
    this.chat.boardId=this.selectedBoardId;
    this.chat.chatInit(boardId);

  }

  onAddTable(){
    const dialogRef = this.dialog.open(NewTableDialogComponent, {
      data: {rename: false} ,
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result != null && result != undefined){
        this.projectService.addDrawingBoard(this.Project.id,result,this.connectionID ).subscribe((response : DrawingBoardModel)=>{
          this.drawingBoards.push(response);
        });
      }
    });  
  }

  shapeSelectionChanged(){
    if(this.drawignBoard != undefined && this.drawignBoard != null){
      if(this.drawignBoard.selectedShape != undefined && this.drawignBoard.selectedShape != null){
        this.shapeTab.disabled = false
        this.shapeProperties.currentFillColor = this.drawignBoard.selectedShape.fillColor;
        this.shapeProperties.currentStrockColor = this.drawignBoard.selectedShape.strockColor;
        this.selectedTabNumber.setValue(2);
      }
      else{
        if(this.selectedTabNumber.value === 2){
          this.shapeTab.disabled = true;
          this.selectedTabNumber.setValue(0);
        }
      }
    }
  }
  deleteShape(){
    this.drawignBoard.deleteShape();
  }

  changeShapeColor(colorObject : any){
   this.drawignBoard.chageShapeColor(colorObject.color,colorObject.isFill);
  }
  onRename(){
    const dialogRef = this.dialog.open(NewTableDialogComponent, {  
      data: {rename: true} 
    }); 
    dialogRef.afterClosed().subscribe(result => {
      if(result != null && result != undefined){
        this.tableService.renameTable(this.selectedBoardId,this.Project.id,result).subscribe((response : DrawingBoardModel)=>{
        });
      }
    });  
  }
  onDelete(){
    const dialogRef = this.dialog.open(DeleteDialogComponent, {  
      data: {leave: false} 
    }); 
    dialogRef.afterClosed().subscribe(result => {
      if(result != null && result != undefined){
        this.tableService.deleteTable(this.selectedBoardId, this.Project.id).subscribe((response : DrawingBoardModel)=>{
        });
      }
    });  
  }
}