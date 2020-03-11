using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class UpdateUserUseCase : IHandle<UpdateUserRequest, UserResponse>
    {
        private IUserRepository _repository;

        public UpdateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserResponse> HandleAsync(UpdateUserRequest request)
        {
            var user = new UserModel
            {
                Id= request.Id,
                Email = request.Email,
                Name = request.Name,
                Username = request.Username,
                Password = request.Password,
                PictureUrl = request.PictureUrl
            };
            var returnUser = await _repository.UpdateAsync(user);

            return returnUser.ToResponse();
        }
    }
}
