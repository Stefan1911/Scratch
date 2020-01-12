using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Boundary.ChatContext.Response;

namespace Boundary.ShapeContext.Response
{
    public class DrawingBoardResponse : IResponseContext
    {
        public string Id { get; set; }
        public ChatResponse Chat { get; set; }
        public List<ShapeResponse> Shapes { get; set; }
    }
}
