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

        public CreateDrawingBoardUseCase(IDrawingBoardRepository repository)
        {
            _repository = repository;
        }
        public async Task<DrawingBoardResponse> HandleAsync(CreateDrawingBoardRequest request)
        {
			var drawingBoard = new DrawingBoardModel();
			var returnDrawingBoard = await _repository.AddAsync(drawingBoard, request.ProjectId	);
			return returnDrawingBoard.ToResponse();
        }

    }
}
