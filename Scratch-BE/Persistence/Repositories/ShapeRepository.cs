using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using Business.Models;
using MongoDB.Bson;
using MongoDB.Driver;

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
			var pr = await _context.Projects.Find(filter).FirstOrDefaultAsync();
			await _context.Projects.UpdateOneAsync(filter,update);
			return shape;
		}

		public Task<IEnumerable<ShapeModel>> GetCollecionAsync(string DrawingBoardId)
		{
			throw new NotImplementedException();
		}
	}
}
