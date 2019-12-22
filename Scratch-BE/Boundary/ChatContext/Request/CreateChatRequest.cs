using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Request
{
    public class CreateChatRequest : IRequestContext
    {
        public List<CreateMessageRequest> Messages { get; set; }
    }
}
