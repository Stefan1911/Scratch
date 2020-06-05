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
    public class DeleteDrawingBoardUseCase : IHandle<DeleteDrawingBoardRequest, DrawingBoardResponse>
    {
        private IDrawingBoardRepository _repository;
        private IDrawingBoardMessageBroker _messageBroker;

        public DeleteDrawingBoardUseCase(IDrawingBoardRepository repository, IDrawingBoardMessageBroker broker)
        {
            _repository = repository;
            _messageBroker = broker;
        }
        public async Task<DrawingBoardResponse> HandleAsync(DeleteDrawingBoardRequest request)
        {
            var returnDrawingBoard = await _repository.GetAsync(request.TableId);
            await _repository.DeleteAsync(request.TableId);
            await _messageBroker.DeleteDrawingBoard(request.ProjectId, request.TableId);
            return returnDrawingBoard.ToResponse();
        }
    }
}
