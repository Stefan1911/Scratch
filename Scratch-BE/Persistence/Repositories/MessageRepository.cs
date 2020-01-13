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

       public async Task<IEnumerable<MessageModel>> GetCollecionAsync(string DrawingBoardId)
        {
            var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(DrawingBoardId));
            var project = await _context.Projects
                                                .Find(filter)
                                                .FirstOrDefaultAsync();

            return project.DrawingBoards
                                    .Where(_board => _board.Id.Equals(DrawingBoardId))
                                    .FirstOrDefault()
                                    .Chat.Messages;
        }
    }
}
