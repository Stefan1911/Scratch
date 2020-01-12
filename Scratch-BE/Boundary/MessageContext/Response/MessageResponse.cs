using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.MessageContext.Response
{
    public class MessageResponse : IResponseContext
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
