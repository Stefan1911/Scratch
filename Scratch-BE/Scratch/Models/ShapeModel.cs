using System.Collections.Generic;

namespace Scratch.Models
{
    public class ShapeModel
    {
        public int Index { get; set; }
        public string TableId { get; set; }
        public List<PointModel> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
    }
}