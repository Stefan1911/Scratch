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
			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id == DrawingBoardId);
			// var project = await _context.Projects.FindAsync(_project => 
			// 													 (_project.DrawingBoards
			// 																.Where(_board => _board.Id == DrawingBoardId)
			// 																.FirstOrDefault() != null)? true:false
			// 												);
			var update = Builders<ProjectModel>.Update
													.Push(_project => _project.DrawingBoards
																					.Where(_board => _board.Id == DrawingBoardId)
																					.FirstOrDefault()
																					.Shapes
														,shape);
			// var board = project
			// 				.FirstOrDefault()
			// 				.DrawingBoards
			// 				.Where(_board => _board.Id == DrawingBoardId)
			// 				.FirstOrDefault();
			// board.Shapes.Add(shape);
			// await _context.Projects.InsertOneAsync(project.FirstOrDefault());
			await _context.Projects.UpdateOneAsync(filter,update);
			return shape;
		}

		public Task<IEnumerable<ShapeModel>> GetCollecionAsync(string DrawingBoardId)
		{
			throw new NotImplementedException();
		}
	}
}
