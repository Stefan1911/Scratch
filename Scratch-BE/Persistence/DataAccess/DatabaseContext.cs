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
			var connectionString = "mongodb://127.0.0.1:27017";
			var databaseName = "preduzece";
			var userCollecionName = "users";
			var projectCollectionName = "projects";
			var serverResponseWaitTime = 2000;

			MongoClient client = new MongoClient(connectionString);
			MongoDB = client.GetDatabase(databaseName);
			bool isActiveServer = MongoDB.RunCommandAsync((Command<BsonDocument>)"{ping:1}")
        											.Wait(serverResponseWaitTime);
			if(!isActiveServer)
				throw new Exception("Mongo server didnt respond: check if the server is rungin");

			Users = MongoDB.GetCollection<UserModel>(userCollecionName);
			Projects = MongoDB.GetCollection<ProjectModel>(projectCollectionName);
        }
       


    }
}
