using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.ChatContext.Request
{
    public class GetChatUsersRequest : IRequestContext
    {
        public string BoardId { get; set; }
    }
}
