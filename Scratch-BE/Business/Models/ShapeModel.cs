using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ShapeModel
    {
        public string Id { get; set; }
        public List<Point> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
    }
}