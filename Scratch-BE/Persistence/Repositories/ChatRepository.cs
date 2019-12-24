using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Driver.Builders;

namespace Persistence.Repositories
{
    public class ChatRepository : IChatRepository
    {
        protected DataAccess.DatabaseContext _context;

        public ChatRepository(DataAccess.DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ChatModel> AddAsync(ChatModel chat, string boardId)
        {
            throw new NotImplementedException();
        }
        Task<ChatModel> IChatRepository.GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ChatModel>> IChatRepository.GetCollecionAsync(string projectId)
        {
            throw new NotImplementedException();
        }
    }
}
