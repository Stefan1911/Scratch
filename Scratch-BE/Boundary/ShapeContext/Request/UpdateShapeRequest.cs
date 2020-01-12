using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ShapeContext.Request
{
    public class UpdateShapeRequest : IRequestContext
    {
        public int Index { get; set; }
        public string TableId { get; set; }
        public IEnumerable<CreatePointRequest> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
    }
}
