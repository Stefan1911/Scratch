using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
    public class CreateDrawingBoardRequest : IRequestContext
    {
        public CreateChatRequest Chat { get; set; }
        public List<CreateShapeRequest> Shapes { get; set; }
    }
}
