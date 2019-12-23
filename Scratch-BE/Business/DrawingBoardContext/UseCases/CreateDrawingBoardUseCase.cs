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
using Business.DrawingBoardContext.Extension;

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
            //    var returnDrawingBoard = await _repository.AddAsync(drawingBoard);
            //      return returnDrawingBoard.ToResponse();
            throw new NotImplementedException();
        }

    }
}
