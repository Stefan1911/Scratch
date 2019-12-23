using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class DrawingBoardModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public ChatModel Chat { get; set; }
        public List<ShapeModel> Shapes { get; set; }

    }
}