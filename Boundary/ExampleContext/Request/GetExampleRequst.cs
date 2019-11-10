using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ExampleContext.Request
{
    public class GetExampleRequst : IRequestContext
    {
        public int Id { get; set; }
    }
}
