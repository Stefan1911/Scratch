﻿using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ShapeContext.Response
{
    public class PointResponse : IResponseContext
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
}
