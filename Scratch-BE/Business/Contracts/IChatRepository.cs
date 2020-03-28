using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IChatRepository
    {
        Task<ChatModel> AddAsync(ChatModel chat, string projectId);
        Task<ICollection<UserModel>> GetUsers(string boardId);
        Task<ChatModel> GetAsync(string id);
    }
}
