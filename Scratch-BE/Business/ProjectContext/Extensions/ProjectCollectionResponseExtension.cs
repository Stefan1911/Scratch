using Boundary.ProjectContext.Response;
using Business.Models;
using Business.UserContext.Extension;
using Kernel.Response;
using Kernel.Response.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProjectContext.Extensions
{
    public static class ProjectCollectionResponseExtension
    {
        public static CollectionResponse<ProjectResponse> ToResponse(this IEnumerable<ProjectModel> projects)
        {
            List<ProjectResponse> returnProjects = new List<ProjectResponse>();
            foreach(ProjectModel project in projects)
            {
                returnProjects.Add(project.ToResponse());
            }
            
            return returnProjects.ToCollecionResponse();
        }
    }
}
