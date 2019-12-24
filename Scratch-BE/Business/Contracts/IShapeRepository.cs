using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IShapeRepository
    {
        Task<ShapeModel> AddAsync(ShapeModel shape, string DrawingBoardId);
        Task<IEnumerable<ShapeModel>> GetCollecionAsync(string DrawingBoardId);
    }
}
