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
        Task<ChatModel> GetAsync(string id);
        Task<IEnumerable<ChatModel>> GetCollecionAsync();
    }
}
