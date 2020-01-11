using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
    public class CreateDrawingBoardRequest : IRequestContext
    {
		public string ProjectId { get; set; }
    }
}
