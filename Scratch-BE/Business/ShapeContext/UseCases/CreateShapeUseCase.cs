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
using System.Linq;

namespace Business.UserContext.UseCases
{
    public class CreateShapeUseCase : IHandle<CreateShapeRequest, ShapeResponse>
    {
        private IShapeRepository _repository;

        public CreateShapeUseCase(IShapeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ShapeResponse> HandleAsync(CreateShapeRequest request)
        {
            var shape = new ShapeModel
            {
                FillColor = request.FillColor,
                StrockColor = request.StrockColor,
                Type = request.Type,
				Points = request.Points.Select( point => {
					return new Point{
						X = point.X,
						Y = point.Y
					};
				}).ToList()
            };
            var returnShape = await _repository.AddAsync(shape,request.TableId);
            return returnShape.ToResponse();
        }

    }
}
