using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.DrawingBoardContext.Request
{
    public class RenameDrawingBoardRequest : IRequestContext
    {
        public string TableId { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }

    }
}
