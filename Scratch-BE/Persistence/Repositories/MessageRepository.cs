using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            await context.Messages.InsertOneAsync(message);
            return message;

        }

        Task<MessageModel> IMessageRepository.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<MessageModel>> IMessageRepository.GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
