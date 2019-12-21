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
        private MongoDatabase MongoDB { get; set; }
        public MongoCollection<ProjectModel> Projects { get; set; }
        public MongoCollection<UserModel> Users { get; set; }
        public DatabaseContext()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            MongoDB = server.GetDatabase("preduzece");
        }
       


    }
}
