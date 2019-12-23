﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Business.Models
{
    public class UserModel
    {
		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> ProjectIDs { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PictureUrl { get; set; }
    }
}
