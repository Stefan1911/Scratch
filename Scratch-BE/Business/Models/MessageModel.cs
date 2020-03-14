using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName  { get; set; }
        public string UserPictureUrl { get; set; }
        public string UserID { get; set; }
        public string Content { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}