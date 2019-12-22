using Boundary.ShapeContext.Request;
using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
    public class CreateShapeRequest : IRequestContext
    {
        public List<CreatePointRequest> Points { get; set; }
        public string FillColor { get; set; }
        public string StrockColor { get; set; }
        public string Type { get; set; }
    }
}
