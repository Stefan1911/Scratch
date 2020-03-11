using Boundary.ProjectContext.Response;
using Business.DrawingBoardContext.Extension;
using Business.Models;
using Kernel.Response.Extensions;
using System.Linq;

namespace Business.UserContext.Extension
{
    public static class ProjectResponseExtension
    {
        public static ProjectResponse ToResponse(this ProjectModel project)
        {
            return new ProjectResponse
            {
                Id = project.Id,
                Description=project.Description,
                PictureUrl=project.PictureUrl,
                Name = project.Name,
                PictureUrl=project.PictureUrl,
                Description=project.Description,
                DrawingBoards = project.DrawingBoards.Select(drawingBoard => drawingBoard.ToResponse()).ToCollecionResponse(),
                UserIDs = project.UserIDs  
            };
        }
    }
}
