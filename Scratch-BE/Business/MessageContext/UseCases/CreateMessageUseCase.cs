using System;
using System.Collections.Generic;
using System.Text;
using Boundary.UserContext;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.UserContext.Extension;
using Business.Models;
using Kernel;
using System.Threading.Tasks;
using Boundary.UserContext.Request;

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
