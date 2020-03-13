using Boundary.ChatContext.Request;
using Boundary.ChatContext.Response;
using Business.ChatContext.Extensions;
using Business.Contracts;
using Business.Models;
using Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ChatContext.UseCases
{
    public class CreateChatUseCase : IHandle<CreateChatRequest, ChatResponse>
    {
        private IChatRepository _repository;
        private IChatMessageBroker _messageBroker;

        public CreateChatUseCase(IChatRepository repository, IChatMessageBroker broker)
        {
            _repository = repository;
           _messageBroker = broker;
        }
        public async Task<ChatResponse> HandleAsync(CreateChatRequest request)
        {
            var chat = new ChatModel
            {
                 
            };
            var returnChat = await _repository.AddAsync(chat, request.TableId);
            await _messageBroker.AddChat(request.TableId, request.ExcludedClientId, returnChat);
            return returnChat.ToResponse();
        }
    }
}
