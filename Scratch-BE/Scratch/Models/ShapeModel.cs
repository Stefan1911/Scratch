using System.Collections.Generic;

namespace Scratch.Models
{
    public class ShapeModel
    {
        public int ShapeIndex { get; set; }
        public string TableId { get; set; }
        public List<PointModel> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
		public string sendingClientID { get; set; }
    }
}