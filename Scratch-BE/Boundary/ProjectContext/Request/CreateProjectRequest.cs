using Boundary.DrawingBoardContext.Request;
using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ProjectContext.Request
{
    public class CreateProjectRequest : IRequestContext
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String PictureUrl { get; set; }
        public List<CreateDrawingBoardRequest> DrawingBoards { get; set; }
        public List<String> UserIDs { get; set; }

    }
}
