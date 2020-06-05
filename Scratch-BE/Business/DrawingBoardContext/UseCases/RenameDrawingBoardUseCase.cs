using Boundary.DrawingBoardContext.Request;
using Boundary.ShapeContext.Response;
using Business.Contracts;
using Business.DrawingBoardContext.Extension;
using Business.Models;
using Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.DrawingBoardContext.UseCases
{
    public class RenameDrawingBoardUseCase : IHandle<RenameDrawingBoardRequest, DrawingBoardResponse>
    {
        private IDrawingBoardRepository _repository;
        private IDrawingBoardMessageBroker _messageBroker;

        public RenameDrawingBoardUseCase(IDrawingBoardRepository repository, IDrawingBoardMessageBroker broker)
        {
            _repository = repository;
            _messageBroker = broker;
        }

        public async Task<DrawingBoardResponse> HandleAsync(RenameDrawingBoardRequest request)
        {
            await _repository.RenameAsync(request.TableId, request.Name);
            var returnDrawingBoard = await _repository.GetAsync(request.TableId);
            await _messageBroker.RenameDrawingBoard(request.ProjectId, request.TableId, request.Name);
            return returnDrawingBoard.ToResponse();
        }
    }
}
