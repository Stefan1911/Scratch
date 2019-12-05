using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Business.Contracts;
using Business.ExampleContext.Extension;
using Business.Models;
using Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ExampleContext.UseCases
{
    public class CreateExampleUseCase : IHandle<CreateExampleRequst, ExampleResponse>
    {
        private IExampleRepository _repository;
        public CreateExampleUseCase(IExampleRepository repository)
        {
            _repository = repository;
        }
        public async Task<ExampleResponse> HandleAsync(CreateExampleRequst request)
        {
            var example = new Example
            {
                Data1 = request.Data1,
                Data2 = request.Data2
            };
            var returnExample = await _repository.AddAsync(example);
            return returnExample.ToResponse() ;
        }
    }
}
