using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using Business.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Persistence.Repositories
{
    public class ShapeRepository: IShapeRepository
    {
        protected DataAccess.DatabaseContext _context;

        public ShapeRepository(DataAccess.DatabaseContext context)
        {
            _context = context;
        }

		public async Task<ShapeModel> AddAsync(ShapeModel shape, string DrawingBoardId)
		{
			shape.Id = ObjectId.GenerateNewId().ToString();
			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(DrawingBoardId));
			var update = Builders<ProjectModel>.Update.Push("DrawingBoards.$.Shapes",shape);
			await _context.Projects.UpdateOneAsync(filter,update);
			return shape;
		}

		public async Task DeleteAsync(string DrawingBoardId, string shapeId)
		{

			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(DrawingBoardId));
			var shapeFilter = Builders<ShapeModel>.Filter.Where(_shape => _shape.Id.Equals(shapeId));
			var update = Builders<ProjectModel>.Update.PullFilter<ShapeModel>("DrawingBoards.$.Shapes",shapeFilter);
			var result = await _context.Projects.UpdateOneAsync(filter,update);
		}

		public async Task<IEnumerable<ShapeModel>> GetCollecionAsync(string DrawingBoardId)
		{
			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(DrawingBoardId));
			var project = await _context.Projects
												.Find(filter)
												.FirstOrDefaultAsync();

			return project.DrawingBoards
									.Where(_board => _board.Id.Equals(DrawingBoardId))
									.FirstOrDefault()
									.Shapes;
		}

		public async Task<ShapeModel> UpdateAsync(int index, ShapeModel shape, string DrawingBoardId)
		{
			IEnumerable<ShapeModel> shapes= await GetCollecionAsync(DrawingBoardId);		
			var shapes2=shapes.ToList();
			shapes2.Insert(index, shape);
			shapes2.RemoveAt(index + 1);
			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(DrawingBoardId));
			var update = Builders<ProjectModel>.Update.Set("DrawingBoards.$.Shapes", shapes2);
			await _context.Projects.UpdateOneAsync(filter, update);
			return shape;
		}
	}
}
