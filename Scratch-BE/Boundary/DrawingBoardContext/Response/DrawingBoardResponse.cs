using Kernel.Response;
using System.Collections.Generic;

namespace Boundary.UserContext.Response
{
    public class DrawingBoardResponse : IResponseContext
    {
        public string Id { get; set; }
        public ChatResponse Chat { get; set; }
        public List<ShapeResponse> Shapes { get; set; }
    }
}
