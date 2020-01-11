using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ShapeContext.Request
{
    public class CreatePointRequest : IRequestContext
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
