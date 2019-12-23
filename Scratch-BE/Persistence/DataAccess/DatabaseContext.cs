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

		
        public DatabaseContext(DatabaseSettings settings)
        {
			MongoClient client = new MongoClient(settings.ConnectionString);
			MongoDB = client.GetDatabase(settings.DatabaseName);
			bool isActiveServer = MongoDB.RunCommandAsync((Command<BsonDocument>)"{ping:1}")
        											.Wait(settings.ServerResponeWaitTime);
			if(!isActiveServer)
				throw new Exception("Mongo server didnt respond: check if the server is running");

			Users = MongoDB.GetCollection<UserModel>(settings.UserCollecionName);
			Projects = MongoDB.GetCollection<ProjectModel>(settings.ProjectCollecionName);
         
        }
       


    }
}
