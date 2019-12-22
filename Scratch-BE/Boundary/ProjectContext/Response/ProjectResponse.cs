using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Response
{
    public class ProjectResponse : IResponseContext
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public CollectionResponse<DrawingBoardResponse> DrawingBoards { get; set; }
        public List<String> UserIDs { get; set; }
    }
}
