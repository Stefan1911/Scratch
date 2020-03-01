using System.Threading.Tasks;
using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.UserContext.Extension;
using Kernel;

namespace Business.UserContext.UseCases
{
    public class LogInUseCase : IHandle<LogInRequest, LogInResponse>
    {
        private IUserRepository _repository;
        public LogInUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<LogInResponse> HandleAsync(LogInRequest request)
        {
            var user = await _repository.GetByUsername(request.Username);
            if(user != null){
                var response = new LogInResponse{
                    User = (user.Password == request.Password)? user.ToResponse() : null,
                    UsernameIncorrect = false
                };
                return response;
            }
            return new LogInResponse{
                User = null,
                UsernameIncorrect = true
            };
        }
    }
}