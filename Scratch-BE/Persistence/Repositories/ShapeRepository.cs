using System;
using System.Collections.Generic;
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
        protected DataAccess.DatabaseContext context;

        public ShapeRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ShapeModel> AddAsync(ShapeModel shape)
        {
            throw new NotImplementedException();

        }
        Task<ShapeModel> IShapeRepository.GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ShapeModel>> IShapeRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
