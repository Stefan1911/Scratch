using System.Linq;
using Boundary.UserContext.Response;
using Business.Models;
using Business.UserContext.Extension;

namespace Business.MessageContext.Extensions
{
    public static class ChatExtensions
    {
        public static ChatResponse ToResponse(this ChatModel chat){
			return new ChatResponse{
				Id = chat.Id,
				Messages = chat.Messages.Select(message => {
					return message.ToResponse();
				}).ToList()
			};
		}
	}
}