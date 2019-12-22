using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DrawingBoardRepository: IDrawingBoardRepository
    {
        protected DataAccess.DatabaseContext context;

        public DrawingBoardRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<DrawingBoardModel> AddAsync(DrawingBoardModel board)
        {
            await context.DrawingBoards.InsertOneAsync(board);
            return board;

        }

        Task<DrawingBoardModel> IDrawingBoardRepository.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DrawingBoardModel>> IDrawingBoardRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
