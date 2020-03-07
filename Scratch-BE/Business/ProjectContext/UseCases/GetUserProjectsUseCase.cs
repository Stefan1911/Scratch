using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Business.Contracts;
using Business.ProjectContext.Extensions;
using Kernel;
using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ProjectContext.UseCases
{
   public  class GetUserProjectsUseCase : IHandle<GetUserProjectsRequest, CollectionResponse<ProjectResponse>>
    {
        private IProjectRepository _projectRepository;

        public GetUserProjectsUseCase(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
         

        public async Task<CollectionResponse<ProjectResponse>> HandleAsync(GetUserProjectsRequest request)
        {
            var returnProject = await _projectRepository.GetProjectOfUserAsync(request.UserId);

            return returnProject.ToResponse();
        }
    }
}
