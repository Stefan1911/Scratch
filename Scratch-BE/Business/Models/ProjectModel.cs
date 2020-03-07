using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ProjectModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String  Name { get; set; }
        public String Description { get; set; }
        public String PictureUrl { get; set; }
        public List<DrawingBoardModel> DrawingBoards { get; set; }
        public List<String> UserIDs { get; set; }

        public ProjectModel()
        {
            this.DrawingBoards = new List<DrawingBoardModel>();
            this.UserIDs = new List<string>();
        }

    }
}
