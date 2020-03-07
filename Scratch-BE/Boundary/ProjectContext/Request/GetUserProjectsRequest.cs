using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ProjectContext.Request
{
    public class GetUserProjectsRequest : IRequestContext
    {
        public string UserId { get; set; }
    }
}
