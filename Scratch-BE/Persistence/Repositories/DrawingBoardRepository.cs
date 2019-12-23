using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Persistence.Repositories
{
    public class DrawingBoardRepository: IDrawingBoardRepository
    {
        protected DataAccess.DatabaseContext context;

        public DrawingBoardRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<DrawingBoardModel> AddAsync(DrawingBoardModel board, string project)
        {
            throw new NotImplementedException();
        }

        public async Task<DrawingBoardModel> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DrawingBoardModel>> GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
