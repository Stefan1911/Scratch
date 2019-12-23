﻿using System;
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

        public async Task<UserModel> AddAsync(UserModel user)
        {
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
    }
}