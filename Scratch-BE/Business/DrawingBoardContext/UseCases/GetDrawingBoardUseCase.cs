using Boundary.DrawingBoardContext.Request;
using Boundary.ShapeContext.Response;
using Business.Contracts;
using Business.DrawingBoardContext.Extension;
using Kernel;
using System.Threading.Tasks;

namespace Business.DrawingBoardContext.UseCases
{
	public class GetDrawingBoardUseCase : IHandle<GetDrawingBoardRequest, DrawingBoardResponse>
    {
		private IDrawingBoardRepository _repository;

        public GetDrawingBoardUseCase(IDrawingBoardRepository repository)
        {
			_repository = repository;
        }

		public async Task<DrawingBoardResponse> HandleAsync(GetDrawingBoardRequest request)
		{
			var drawingBoard = await _repository.GetAsync(request.boardId);
			return drawingBoard.ToResponse();
		}
	}
}