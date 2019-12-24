using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Persistence.Repositories
{
    public class DrawingBoardRepository: IDrawingBoardRepository
    {
        protected DataAccess.DatabaseContext _context;

        public DrawingBoardRepository(DataAccess.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<DrawingBoardModel> AddAsync(DrawingBoardModel board, string projectId)
        {
			board.Id = ObjectId.GenerateNewId().ToString();
			var filter = Builders<ProjectModel>.Filter.Eq(_project => _project.Id, projectId);
			var update = Builders<ProjectModel>.Update.Push(_project => _project.DrawingBoards,board);
			await _context.Projects.UpdateOneAsync(filter,update);
			return board;
        }

        public async Task<DrawingBoardModel> GetAsync(string drawingBoardId)
        {
			var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(drawingBoardId));
			var project = await _context.Projects
												.Find(filter)
												.FirstOrDefaultAsync();
			return project.DrawingBoards
									.Where(_board => _board.Id.Equals(drawingBoardId))
									.FirstOrDefault();
        }

        public async Task<IEnumerable<DrawingBoardModel>> GetCollecionAsync(string projectId)
        {
            var project = await _context.Projects.Find(x => x.Id.Equals(projectId)).FirstOrDefaultAsync();
            return project.DrawingBoards.ToList();
        }
    }
}
