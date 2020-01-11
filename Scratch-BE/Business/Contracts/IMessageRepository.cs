using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IMessageRepository
    {
        Task<MessageModel> AddAsync(MessageModel message, string boardId);
        Task<MessageModel> GetAsync(string id);
        Task<IEnumerable<MessageModel>> GetCollecionAsync();
    }
}
