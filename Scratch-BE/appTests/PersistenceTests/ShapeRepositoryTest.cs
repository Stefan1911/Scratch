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

        [Fact]
        public async void GetAsyncTest()
        {
            var boardRepository = appTestDependencyHelper.drawingBoardRepository;
            var projectRepository = appTestDependencyHelper.projectRepository;
            var shapeRepository = appTestDependencyHelper.shapeRepository;

            A.Configure<ProjectModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.DrawingBoards, () => {
                  return new List<DrawingBoardModel>();
              });

            var project = A.New<ProjectModel>();
            project = await projectRepository.AddAsync(project);

            A.Configure<DrawingBoardModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.Shapes, () => {
                  return new List<ShapeModel>();
              });

            var board = A.New<DrawingBoardModel>();
            board = await boardRepository.AddAsync(board, project.Id);

            A.Configure<ShapeModel>()
             .Fill(c => c.Id, () => { return null; });

            var shapes = A.ListOf<ShapeModel>(5);
            List<ShapeModel> shapesFrom = new List<ShapeModel>();

            foreach(ShapeModel shape in shapes)
             shapesFrom.Add(await shapeRepository.AddAsync(shape, board.Id));

           board = await boardRepository.GetAsync(board.Id);
           var shapesGet = await shapeRepository.GetCollecionAsync(board.Id);

           for(int i=0; i< shapesGet.Count(); i++)
                Assert.Equal(shapesGet.ToList()[i].Id, shapesFrom[i].Id);
        }


        [Fact]
        public async void UpdateAsyncTest()
        {
            var boardRepository = appTestDependencyHelper.drawingBoardRepository;
            var projectRepository = appTestDependencyHelper.projectRepository;
            var shapeRepository = appTestDependencyHelper.shapeRepository;

            A.Configure<ProjectModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.DrawingBoards, () => {
                  return new List<DrawingBoardModel>();
              });

            var project = A.New<ProjectModel>();
            project = await projectRepository.AddAsync(project);

            A.Configure<DrawingBoardModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.Shapes, () => {
                  return new List<ShapeModel>();
              });

            var board = A.New<DrawingBoardModel>();
            board = await boardRepository.AddAsync(board, project.Id);

            A.Configure<ShapeModel>()
             .Fill(c => c.Id, () => { return null; });

            var shapes = A.ListOf<ShapeModel>(3);
            var shape2 = A.New<ShapeModel>();

            foreach (ShapeModel shape in shapes)
                await shapeRepository.AddAsync(shape, board.Id);

            var shapes2 = await shapeRepository.GetCollecionAsync(board.Id);
            shape2 = await shapeRepository.UpdateAsync(0,shape2,board.Id);

            Assert.NotEqual(shapes2.ToList()[0], shape2);
        }
    }
}