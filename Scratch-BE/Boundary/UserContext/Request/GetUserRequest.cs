using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
   public class GetUserRequest : IRequestContext
    {
        public string Id { get; set; }
    }
}
