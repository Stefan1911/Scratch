using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.MessageContext.Request
{
    public class CreateMessageRequest : IRequestContext
    {
        public string UserID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
