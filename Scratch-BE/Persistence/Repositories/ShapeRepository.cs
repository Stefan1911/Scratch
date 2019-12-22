using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using Business.Models;

namespace Persistence.Repositories
{
    public class ShapeRepository: IShapeRepository
    {
        protected DataAccess.DatabaseContext context;

        public ShapeRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ShapeModel> AddAsync(ShapeModel shape)
        {
            await context.Shapes.InsertOneAsync(shape);
            return shape;

        }
        Task<ShapeModel> IShapeRepository.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ShapeModel>> IShapeRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
