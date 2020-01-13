using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Boundary.MessageContext.Request;

namespace Boundary.ChatContext.Request
{
    public class CreateChatRequest : IRequestContext
    {
        public string TableId { get; set; }
        public List<CreateMessageRequest> Messages { get; set; }
    }
}
