using Boundary.DrawingBoardContext.Request;
using Boundary.ShapeContext.Response;
using Business.Contracts;
using Business.DrawingBoardContext.Extension;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class CreateDrawingBoardUseCase : IHandle<CreateDrawingBoardRequest, DrawingBoardResponse>
    {
        private IDrawingBoardRepository _repository;
        private IDrawingBoardMessageBroker _messageBroker;

        public CreateDrawingBoardUseCase(IDrawingBoardRepository repository, IDrawingBoardMessageBroker broker)
        {
            _repository = repository;
            _messageBroker = broker;
        }
        public async Task<DrawingBoardResponse> HandleAsync(CreateDrawingBoardRequest request)
        {
			var drawingBoard = new DrawingBoardModel{
                Name = request.Name
            };
			var returnDrawingBoard = await _repository.AddAsync(drawingBoard, request.ProjectId	);
            await _messageBroker.AddDrawingBoard(request.ProjectId,request.ExcludedClientId,returnDrawingBoard);
			return returnDrawingBoard.ToResponse();
        }

    }
}
