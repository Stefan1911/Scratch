using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Response
{
    public class ChatResponse : IResponseContext
    {
        public string Id { get; set; }
        public List<MessageResponse> Messages { get; set; }
    }
}
