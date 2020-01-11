using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ShapeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Point> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }

		public ShapeModel()
		{
			this.Points = new List<Point>();
		}
    }
}