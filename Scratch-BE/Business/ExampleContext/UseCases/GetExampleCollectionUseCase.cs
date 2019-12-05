using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Business.Contracts;
using Business.ExampleContext.Extension;
using Business.Models;
using Kernel;
using Kernel.Response;
using Kernel.Response.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ExampleContext.UseCases
{
    public class GetExampleCollectionUseCase : IHandle<GetExampleCollecionRequest, CollectionResponse<ExampleResponse>>
    {
        private IExampleRepository _repository;
        public GetExampleCollectionUseCase(IExampleRepository repository)
        {
            _repository = repository;
        }
        public async Task<CollectionResponse<ExampleResponse>> HandleAsync(GetExampleCollecionRequest request)
        {
            var collecion = await _repository.GetCollecionAsync();
            var response = collecion
                .Select(example => example.ToResponse())
                .ToCollecionResponse();
            return response;
        }
    }
}
