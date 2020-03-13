using Boundary.ChatContext.Request;
using Boundary.ChatContext.Response;
using Business.ChatContext.Extensions;
using Business.Contracts;
using Kernel;
using System.Threading.Tasks;

namespace Business.ChatContext.UseCases
{
	public class GetChatUseCase : IHandle<GetChatRequest, ChatResponse>
	{
		private IChatRepository _repository;

		public GetChatUseCase(IChatRepository repository)
		{
			_repository = repository;
		}

		public async Task<ChatResponse> HandleAsync(GetChatRequest request)
		{
			var chat = await _repository.GetAsync(request.BoardId);
			return chat.ToResponse();
		}
	}
}
