using System;
using System.Collections.Generic;
using System.Text;
using Boundary.UserContext.Response;
using Business.Models;

namespace Business.DrawingBoardContext.Extension
{
    public static class DrawingBoardResponseExtension
    {
        public static DrawingBoardResponse ToResponse(this DrawingBoardModel drawingBoard)
        {
            return new DrawingBoardResponse
            {
                Id = drawingBoard.Id,
            };
        }
    }
}
