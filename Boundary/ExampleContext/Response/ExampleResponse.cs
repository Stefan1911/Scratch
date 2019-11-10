using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ExampleContext.Response
{
    public class ExampleResponse : IResponseContext
    {
        public int Id { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
    }
}
