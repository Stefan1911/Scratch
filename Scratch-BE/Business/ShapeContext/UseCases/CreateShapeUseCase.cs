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
    public class CreateShapeUseCase : IHandle<CreateShapeRequest, ShapeResponse>
    {
        private IShapeRepository _repository;

        public CreateShapeUseCase(IShapeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ShapeResponse> HandleAsync(CreateShapeRequest shape)
        {
            var sshape = new ShapeModel
            {
                FillColor = shape.FillColor,
                StrockColor = shape.StrockColor,
                Type = shape.Type

            };
            var returnShape = await _repository.AddAsync(sshape);
            return returnShape.ToResponse();
        }

    }
}
