using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ShapeContext.Request
{
    public class CreatePointRequest : IRequestContext
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
