using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
    public class CreateProjectRequest : IRequestContext
    {
        public String Name { get; set; }
        public List<CreateDrawingBoardRequest> DrawingBoards { get; set; }
        public List<String> UserIDs { get; set; }

    }
}
