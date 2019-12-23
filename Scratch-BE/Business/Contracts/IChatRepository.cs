﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IChatRepository
    {
        Task<ChatModel> AddAsync(ChatModel chat);
        Task<ChatModel> GetAsync(int id);
        Task<IEnumerable<ChatModel>> GetCollecionAsync();
    }
}