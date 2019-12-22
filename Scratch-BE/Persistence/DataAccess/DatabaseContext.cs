using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Business.Models;

namespace Persistence.DataAccess
{
    public class DatabaseContext
    {
        private IMongoDatabase MongoDB { get; set; }
        public IMongoCollection<ProjectModel> Projects { get; set; }
        public IMongoCollection<UserModel> Users { get; set; }
        public IMongoCollection<ChatModel> Chats { get; set; }
        public IMongoCollection<DrawingBoardModel> DrawingBoards { get; set; }
        public IMongoCollection<MessageModel> Messages { get; set; }
        public IMongoCollection<ShapeModel> Shapes { get; set; }
        public DatabaseContext()
        {
            var connectionString = "mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb";
            MongoClient client = new MongoClient(connectionString);
            MongoDB = client.GetDatabase("preduzece");

            Users= MongoDB.GetCollection<UserModel>("users");
            Messages = MongoDB.GetCollection<MessageModel>("messages");
            Shapes = MongoDB.GetCollection<ShapeModel>("shapes");
            Chats = MongoDB.GetCollection<ChatModel>("chats");
            DrawingBoards = MongoDB.GetCollection<DrawingBoardModel>("drawingBoards");
            Projects = MongoDB.GetCollection<ProjectModel>("projects");
        }
       


    }
}
