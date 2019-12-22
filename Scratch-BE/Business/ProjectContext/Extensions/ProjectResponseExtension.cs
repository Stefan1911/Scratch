using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boundary.UserContext.Response;
using Business.DrawingBoardContext.Extension;
using Business.Models;
using Kernel.Response.Extensions;

namespace Business.UserContext.Extension
{
    public static class ProjectResponseExtension
    {
        public static ProjectResponse ToResponse(this ProjectModel project)
        {
            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                DrawingBoards = project.DrawingBoards.Select(drawingBoard => drawingBoard.ToResponse()).ToCollecionResponse(),
                UserIDs = project.UserIDs  
            };
        }
    }
}
