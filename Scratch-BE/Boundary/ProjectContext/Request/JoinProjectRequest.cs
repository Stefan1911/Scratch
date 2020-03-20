using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ProjectContext.Request
{
    public class JoinProjectRequest : IRequestContext
    {
        public string ProjectId { get; set; }
        public string UserId { get; set; }
    }
}
