using System.Collections.Generic;
using System.Linq;
using Business.Models;
using GenFu;
using MongoDB.Bson;
using Xunit;

namespace appTests.PersistenceTests
{
    public class ShapeRepositoryTest
    {
        [Fact]
		public async void  addShapeAsyncTest()
		{
		//Given
			var shapeRepository = appTestDependencyHelper.shapeRepository;
			var projectRepository = appTestDependencyHelper.projectRepository;

			var drawingBoardId = ObjectId.GenerateNewId().ToString();
			var newDrawingBoard = new DrawingBoardModel{
					Id = drawingBoardId, 
					Shapes = new List<ShapeModel>()
					};
			A.Configure<ProjectModel>()
				.Fill(_project => _project.Id, () => {return null;})
				.Fill(_project => _project.DrawingBoards,() => {return new List<DrawingBoardModel>{newDrawingBoard};});
			var newProject = A.New<ProjectModel>();
			A.Configure<ShapeModel>()
              .Fill(shape => shape.Id, () => { return null; })
			  .Fill(shape => shape.Points, () => { 
				var pointOne = new Point {X = 20, Y= 30}; 
				var pointTwo = new Point {X = 50, Y= 42}; 
				var list = new List<Point> {pointOne,pointTwo};
				return list;});
			var newShape = A.New<ShapeModel>();
			var newShape2 = A.New<ShapeModel>();
		//When
			await projectRepository.AddAsync(newProject);
			newShape = await shapeRepository.AddAsync(newShape,drawingBoardId);
			newShape2 = await shapeRepository.AddAsync(newShape2,drawingBoardId);

			await shapeRepository.DeleteAsync(newShape.Id,drawingBoardId);
		//Then
			Assert.NotNull(newShape.Id);
		}
    }
}