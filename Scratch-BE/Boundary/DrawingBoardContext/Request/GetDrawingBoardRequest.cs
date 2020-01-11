using System;
using System.Collections.Generic;
using System.Text;
using Kernel.Request;

namespace Boundary.UserContext.Request
{
    public class GetDrawingBoardRequest : IRequestContext
    {
		public string projectId { get; set; }
		public string boardId { get; set; }
    }
}
