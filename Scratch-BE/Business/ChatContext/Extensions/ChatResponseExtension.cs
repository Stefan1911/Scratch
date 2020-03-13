using Boundary.ChatContext.Response;
using Business.MessageContext.Extensions;
using Business.Models;
using Business.UserContext.Extension;
using System.Linq;

namespace Business.ChatContext.Extensions
{
    public static class ChatResponseExtension
    {
        public static ChatResponse ToResponse(this ChatModel chat)
        {
            return new ChatResponse
            {
                Id = chat.Id,
                Messages = chat.Messages.Select(message => {
                    return message.ToResponse();
                }).ToList()
            };
        }
    }
}
