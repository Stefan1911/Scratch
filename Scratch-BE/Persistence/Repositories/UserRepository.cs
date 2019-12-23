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
    public class UserRepository : IUserRepository
    {
        protected DataAccess.DatabaseContext _context;

        public UserRepository(DataAccess.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            await _context.Users.InsertOneAsync(user);
            return user;

        }

        public Task<IEnumerable<UserModel>> AddRangeAsync(IEnumerable<UserModel> users)
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

        public Task<IEnumerable<UserModel>> GetRangeAsync(IEnumerable<string> userIDs)
        {
            throw new NotImplementedException();
        }
    }
}
