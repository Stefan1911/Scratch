import { RectangleShapeModel } from 'src/app/models/Shapes/RectangleShapeModel';
import { CircleShapeModel } from 'src/app/models/Shapes/CircleShapeModel';
import { LineShapeModel } from 'src/app/models/Shapes/LineShapeModel';
import { Injectable } from '@angular/core';
import { ShapeNames } from 'src/app/models/interfaces/Drawable';
import { MultiLineShapeModel } from 'src/app/models/Shapes/MultiLineShapeModel';
import { PolygonShapeModel } from 'src/app/models/Shapes/PolygonShapeModel';

@Injectable({ providedIn: 'root'})
export class ShapeFactory {
    constructor() {
    }

    getShape(shapeName : ShapeNames){
        switch (shapeName) {
            case ShapeNames.Rectangle:
                return new RectangleShapeModel();
                break;
            case ShapeNames.Circle:
                return new CircleShapeModel();
                break;
            case ShapeNames.Line:
                return new LineShapeModel();
                break;
            case ShapeNames.multiLine:
                return new MultiLineShapeModel();
                break;
            case ShapeNames.polygon:
                return new PolygonShapeModel();
                break;
            default:
                return null
                break;
        }
    }
}