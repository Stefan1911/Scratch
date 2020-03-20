using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System.Threading.Tasks;

namespace Business.ProjectContext.UseCases
{
    public class JoinProjectUseCase : IHandle<JoinProjectRequest, ProjectResponse>
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;
        public JoinProjectUseCase(IProjectRepository repository, IUserRepository userRepository)
        {
            _projectRepository = repository;
            _userRepository = userRepository;
        }
        public async Task<ProjectResponse> HandleAsync(JoinProjectRequest request)
        {
            await _userRepository.JoinProjectAsync(request.UserId, request.ProjectId);
            await _projectRepository.JoinProjectAsync(request.UserId, request.ProjectId);
            ProjectModel returnProject = await _projectRepository.GetAsync(request.ProjectId);
            return returnProject.ToResponse();
        }

    }
}
