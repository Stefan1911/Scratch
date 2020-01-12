using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        protected DataAccess.DatabaseContext _context;

        public MessageRepository(DataAccess.DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<MessageModel> AddAsync(MessageModel message, string boardId)
        {
            message.Id = ObjectId.GenerateNewId().ToString();
            var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(boardId));
            var update = Builders<ProjectModel>.Update.Push("DrawingBoards.$.Chat.Messages", message);

            await _context.Projects.UpdateOneAsync(filter, update);
            return message;
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
\