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
            chat.Id = ObjectId.GenerateNewId().ToString();
            var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(boardId));
            var update = Builders<ProjectModel>.Update.Set("DrawingBoards.$.Chat", chat);
            var pr = await _context.Projects.Find(filter).FirstOrDefaultAsync();
            await _context.Projects.UpdateOneAsync(filter, update);
            return chat;
        }
       public async Task<ChatModel> GetAsync(string drawingBoardId)
        {

            var filter = Builders<ProjectModel>.Filter.ElemMatch(_project => _project.DrawingBoards, _board => _board.Id.Equals(drawingBoardId));
            var project = await _context.Projects
                                                .Find(filter)
                                                .FirstOrDefaultAsync();
                                                
            return project.DrawingBoards
                                    .Where(_board => _board.Id.Equals(drawingBoardId))
                                    .FirstOrDefault()
                                    .Chat;
        }

       
    }
}
