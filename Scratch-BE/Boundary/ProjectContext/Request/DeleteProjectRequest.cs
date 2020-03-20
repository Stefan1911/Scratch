using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ProjectContext.Request
{
    public class DeleteProjectRequest : IRequestContext
    {
        public string ProjectId { get; set; }
    }
}

