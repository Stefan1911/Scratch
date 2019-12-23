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
    public class MessageRepository : IMessageRepository
    {
        protected DataAccess.DatabaseContext context;

        public MessageRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<MessageModel> AddAsync(MessageModel message)
        {
            throw new NotImplementedException();

        }

        Task<MessageModel> IMessageRepository.GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<MessageModel>> IMessageRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
