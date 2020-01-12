using Boundary.MessageContext.Request;
using Boundary.MessageContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class CreateMessageUseCase : IHandle<CreateMessageRequest, MessageResponse>
    {
        private IMessageRepository _repository;

        public CreateMessageUseCase(IMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<MessageResponse> HandleAsync(CreateMessageRequest request)
        {
            var message = new MessageModel
            {
                TimeStamp = request.TimeStamp,
                UserID = request.UserID

            };
            var returnMessage = await _repository.AddAsync(message);
            return returnMessage.ToResponse();
        }

    }
}
