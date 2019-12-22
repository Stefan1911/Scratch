using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using Kernel.Response;
using Kernel.Response.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class GetUserCollectionUseCase : IHandle<GetUserCollectionRequest, CollectionResponse<UserResponse>>
    {
        private IUserRepository _repository;

        public GetUserCollectionUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<CollectionResponse<UserResponse>> HandleAsync(GetUserCollectionRequest request)
        {
            var collecion = await _repository.GetCollecionAsync();
            var response = collecion
                .Select(user => user.ToResponse())
                .ToCollecionResponse();
            return response;
        }
    }
}
