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
using Microsoft.AspNetCore.SignalR;
using MessagingService;

namespace Business.UserContext.UseCases
{
    public class CreateShapeUseCase : IHandle<CreateShapeRequest, ShapeResponse>
    {
        private IShapeRepository _repository;
		private IHubContext<DrawingBoardHub> _messagingHub;


        public CreateShapeUseCase(IShapeRepository repository, IHubContext<DrawingBoardHub> hub)
        {
            _repository = repository;
			_messagingHub = hub;
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
			await _messagingHub.Clients.All.SendAsync(request.TableId,returnShape);
            return returnShape.ToResponse();
        }

    }
}
