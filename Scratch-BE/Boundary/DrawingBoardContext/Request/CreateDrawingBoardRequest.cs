using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.DrawingBoardContext.Request
{
    public class CreateDrawingBoardRequest : IRequestContext
    {
  		public string ProjectId { get; set; }
        public string Name { get; set; }
        public string ExcludedClientId { get; set; }
    }
}
