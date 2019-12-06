import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawingStationComponent } from './drawing-station.component';

describe('DrawingStationComponent', () => {
  let component: DrawingStationComponent;
  let fixture: ComponentFixture<DrawingStationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrawingStationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrawingStationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
