import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MouseStrategyFactory, MouseStrategyEnum } from '../services/mousStratey/MouseStrategyFactory';
import { ProjectModel } from '../models/ProjectModel';
import { DrawingBoardModel } from '../models/DrawingBoardModel';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from '../services/httpServices/projectService';
import { AppCanvasComponent } from './app-canvas/app-canvas.component';
import { MatDialog } from '@angular/material/dialog';
import { NewTableDialogComponent } from '../components/new-table-dialog/new-table-dialog.component';
import { SignalRResiver } from '../services/httpServices/signalRReciver';

@Component({
  selector: 'app-drawing-station',
  templateUrl: './drawing-station.component.html',
  styleUrls: ['./drawing-station.component.css'],
})
export class DrawingStationComponent implements OnInit {
  @ViewChild("canvas", {static: false})
  drawignBoard : AppCanvasComponent;

  Project : ProjectModel;
  selectedBoardId: string;

  connectionID:string
  public drawingBoards : DrawingBoardModel[];
  constructor(private router : ActivatedRoute,private projectService : ProjectService,public dialog: MatDialog, public reciver : SignalRResiver) {
    let projectId = this.router.snapshot.params["projectId"]; 
    this.projectService.getProject(projectId).subscribe((Response : any)=>{      
      this.Project = Response;
      this.drawingBoards = Response.drawingBoards;
      this.selectedBoardId = this.drawingBoards[0].id; 
      this.drawignBoard.projectId = projectId 
      this.drawignBoard.initShapes(this.selectedBoardId);   
      this.reciver.registerDrawingStation(this).then( (mightBeTheId) =>{
        this.connectionID = mightBeTheId
      });
    this
    })
   }


  ngOnInit() {
 
  }

  onToolChange(tool){
    this.drawignBoard.setTool(tool);
  }

  onBoardChange(boardId :string){
    this.selectedBoardId = boardId;
    this.drawignBoard.initShapes(boardId);
  }

  onAddTable(){
    const dialogRef = this.dialog.open(NewTableDialogComponent, {
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

}

