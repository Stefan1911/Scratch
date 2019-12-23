﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserRepository
    {
        Task<UserModel> AddAsync(UserModel instance);
        Task<IEnumerable<UserModel>> GetRangeAsync(IEnumerable<string> userIDs);
        Task<IEnumerable<UserModel>> AddRangeAsync(IEnumerable<UserModel> users);
        Task<UserModel> GetAsync(string id);
        Task<IEnumerable<UserModel>> GetCollecionAsync();
    }
}