using Boundary.UserContext;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.UserContext.Extension;
using Business.Models;
using Kernel;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.UserContext.UseCases
{
   public class CreateUserUseCase : IHandle<CreateUserRequest, LogInResponse>
    {
        private IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<LogInResponse> HandleAsync(CreateUserRequest request)
        {
            var user = new UserModel
            {
                Email = request.Email,
                Name = request.Name,
                Username = request.Username,
                Password = request.Password,
                PictureUrl = request.PictureUrl
            };
            var returnUser = await _repository.AddAsync(user);

            return new LogInResponse() {
                User = returnUser.ToResponse(),
                UsernameIncorrect = false
            };
        }

        
    }
}
