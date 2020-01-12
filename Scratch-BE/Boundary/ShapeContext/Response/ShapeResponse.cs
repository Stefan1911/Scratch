using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ShapeContext.Response
{
    public class ShapeResponse : IResponseContext
    {
        public string Id { get; set; }
        public List<PointResponse> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
    }
}
