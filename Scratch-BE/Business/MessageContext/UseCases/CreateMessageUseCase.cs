using Boundary.MessageContext.Request;
using Boundary.MessageContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class CreateMessageUseCase : IHandle<CreateMessageRequest, MessageResponse>
    {
        private IMessageRepository _repository;
        private IChatMessageBroker _broker;

        public CreateMessageUseCase(IMessageRepository repository, IChatMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }
        public async Task<MessageResponse> HandleAsync(CreateMessageRequest request)
        {
            var message = new MessageModel
            {
                TimeStamp = request.TimeStamp,
                UserID = request.UserID,
                UserPictureUrl=request.UserPictureUrl,
                UserName=request.UserName,
                Content=request.Content
            };
            var returnMessage = await _repository.AddAsync(message, request.TableId);
            await _broker.AddChat(request.TableId, message);
            return returnMessage.ToResponse();
        }

    }
}
