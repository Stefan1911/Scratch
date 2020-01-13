using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Models
{
    public class ChatModel
    {
        public string TableId { get; set; }
        public List<MessageModel> Messages { get; set; }

    }
}
