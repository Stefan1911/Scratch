using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IChatMessageBroker
    {
        Task AddChat(string MessageName, MessageModel mes);
    }
}
