﻿using Business.UserContext.Extension;
using Boundary.UserContext.Response;
using Business.Models;
using Business.MessageContext.Extensions;
using System.Linq;

namespace Business.DrawingBoardContext.Extension
{
    public static class DrawingBoardResponseExtension
    {
        public static DrawingBoardResponse ToResponse(this DrawingBoardModel drawingBoard)
        {
            return new DrawingBoardResponse
            {
                Id = drawingBoard.Id,
				Chat = drawingBoard.Chat.ToResponse(),
				Shapes = drawingBoard.Shapes.Select(shape => {
					return shape.ToResponse();
				}).ToList()
            };
        }
    }
}
