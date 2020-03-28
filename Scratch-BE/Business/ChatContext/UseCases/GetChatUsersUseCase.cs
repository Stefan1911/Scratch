using Boundary.ChatContext.Request;
using Boundary.UserContext.Response;
using Business.ChatContext.Extensions;
using Business.Contracts;
using Kernel;
using Kernel.Response;
using System.Threading.Tasks;

namespace Business.ChatContext.UseCases
{
    public class GetChatUsersUseCase : IHandle<GetChatUsersRequest, CollectionResponse<UserResponse>>
    {
        private IChatRepository _repository;
       
        public GetChatUsersUseCase(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task<CollectionResponse<UserResponse>> HandleAsync(GetChatUsersRequest request)
        {
            var users = await _repository.GetUsers(request.BoardId);
            return users.ToResponse();
        }
    }
}
