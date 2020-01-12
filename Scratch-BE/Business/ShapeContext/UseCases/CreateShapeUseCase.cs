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
		private IDrawingBoardMessageBroker _messageBroker;
        public CreateShapeUseCase(IShapeRepository repository, IDrawingBoardMessageBroker broker)
        {
            _repository = repository;
			_messageBroker = broker;
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
			await _messageBroker.PushShape(request.TableId,returnShape);
            return returnShape.ToResponse();
        }

    }
}
