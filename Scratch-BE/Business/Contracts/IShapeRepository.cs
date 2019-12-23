using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IShapeRepository
    {
        Task<ShapeModel> AddAsync(ShapeModel shape);
        Task<ShapeModel> GetAsync(string id);
        Task<IEnumerable<ShapeModel>> GetCollecionAsync();
    }
}
