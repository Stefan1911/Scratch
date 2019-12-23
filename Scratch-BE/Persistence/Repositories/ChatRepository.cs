using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Persistence.Repositories
{
    public class ChatRepository : IChatRepository
    {
        protected DataAccess.DatabaseContext context;

        public ChatRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ChatModel> AddAsync(ChatModel chat)
        {

            throw new NotImplementedException();
        }

        Task<ChatModel> IChatRepository.GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ChatModel>> IChatRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
