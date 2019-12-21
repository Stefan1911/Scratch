using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using Business.Models;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected DataAccess.DatabaseContext context;

        public UserRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public Task<UserModel> AddAsync(UserModel instance)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
