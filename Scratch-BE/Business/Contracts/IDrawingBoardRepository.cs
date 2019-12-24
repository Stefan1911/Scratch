using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IDrawingBoardRepository
    {
        Task<DrawingBoardModel> AddAsync(DrawingBoardModel board, string project);
        Task<DrawingBoardModel> GetAsync(string id);
        Task<IEnumerable<DrawingBoardModel>> GetCollecionAsync(string projectId);
    }
}
