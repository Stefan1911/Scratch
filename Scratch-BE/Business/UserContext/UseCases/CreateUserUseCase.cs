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
   public class CreateUserUseCase : IHandle<CreateUserRequest, UserResponse>
    {
        private IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserResponse> HandleAsync(CreateUserRequest request)
        {
            var user = new UserModel
            {
                Name = request.Name,
                Password = request.Password,
                PictureUrl = request.PictureUrl,
                ProjectIDs = request.ProjectIDs

            };
            var returnUser = await _repository.AddAsync(user);
            return returnUser.ToResponse();
        }

        
    }
}
