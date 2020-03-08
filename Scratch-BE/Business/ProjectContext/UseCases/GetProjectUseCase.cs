using System.Threading.Tasks;
using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Business.Contracts;
using Business.UserContext.Extension;
using Kernel;

namespace Business.ProjectContext.UseCases
{
    public class GetProjectUseCase : IHandle<GetProjectRequest, ProjectResponse>
    {
        private IProjectRepository _projectRepository;
        public GetProjectUseCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectResponse> HandleAsync(GetProjectRequest request)
        {
            var project = await _projectRepository.GetAsync(request.ProjectId);
            return project.ToResponse();
        }
    }
}