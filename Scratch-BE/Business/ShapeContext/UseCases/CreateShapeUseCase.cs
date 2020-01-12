﻿using Boundary.ShapeContext.Request;
using Boundary.ShapeContext.Response;
using Business.Contracts;
using Business.Models;
using Business.ShapeContext.Extension;
using Kernel;
using System.Linq;
using System.Threading.Tasks;

namespace Business.ShapeContext.UseCases
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
