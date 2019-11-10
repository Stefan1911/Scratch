using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ExampleContext.Request
{
    public class CreateExampleRequst : IRequestContext
    {
        public string Data1 { get; set; }
        public String Data2 { get; set; }
    }
}
