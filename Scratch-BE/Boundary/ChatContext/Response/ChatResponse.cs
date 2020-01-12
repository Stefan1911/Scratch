using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Boundary.MessageContext.Response;

namespace Boundary.ChatContext.Response
{
    public class ChatResponse : IResponseContext
    {
        public string Id { get; set; }
        public List<MessageResponse> Messages { get; set; }
    }
}
