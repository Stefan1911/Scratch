using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task DeleteProjectAsync(string projectId,string userId)
        {
            var deleteFilter = Builders<UserModel>.Filter.Eq(user => user.Id,userId);
            var update = Builders<UserModel>.Update.Pull(user => user.ProjectIDs, projectId);
            await _context.Users.UpdateManyAsync(deleteFilter, update);
        }
        public async Task JoinProjectAsync(string userId, string projectId)
        {
            var filter = Builders<UserModel>.Filter.Eq(user => user.Id,userId);
            var update = Builders<UserModel>.Update.Push(user => user.ProjectIDs, projectId);
            await _context.Users.UpdateOneAsync(filter, update);
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            var dbUser = await this.GetByUsername(user.Username);
            if(dbUser != null)
                throw new Exception("username already exists");
                
            await _context.Users.InsertOneAsync(user);
            return user;
        }

        public async Task<IEnumerable<UserModel>> AddRangeAsync(IEnumerable<UserModel> users)
        {
            await _context.Users.InsertManyAsync(users);
            return users;
        }

        public async Task<UserModel> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(i => i.Id.Equals(id));
            return await user.FirstOrDefaultAsync();    
           
        }

        public async Task<UserModel> GetByUsername(string username)
        {
            var user = await _context.Users.FindAsync(i => i.Username.Equals(username));
            return await user.FirstOrDefaultAsync();  
        }

        public async Task<IEnumerable<UserModel>> GetCollecionAsync()
        {
            var user = await _context.Users.FindAsync(x=>true);
            return user.ToList();
        }

        public async Task<IEnumerable<UserModel>> GetRangeAsync(IEnumerable<string> userIDs)
        {
            var users= await _context.Users.FindAsync(x => userIDs.Contains(x.Id));         
            return users.ToList();
        }

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq(_user => _user.Id, user.Id);
            var builder = Builders<UserModel>.Update;
            var update = builder.Set(_user => _user.Name, user.Name).Set(_user => _user.Username, user.Username)
                .Set(_user => _user.PictureUrl, user.PictureUrl).Set(_user => _user.Email, user.Email);

            await _context.Users.UpdateOneAsync(filter, update);
            return user;
        }

        public async Task UpdateRangeAsync(IEnumerable<string> users,string projectId)
        {
            var filter = Builders<UserModel>.Filter.Where(user => users.Contains(user.Id));
            var update = Builders<UserModel>.Update.Push(user => user.ProjectIDs, projectId);
            await _context.Users.UpdateManyAsync(filter, update);
        }
    }
}
