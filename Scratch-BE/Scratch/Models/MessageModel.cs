using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Models
{
    public class MessageModel
    {
        public string UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TableId { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserPictureUrl { get; set; }

    }
}
