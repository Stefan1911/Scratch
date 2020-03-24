using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ProjectContext.UseCases
{
    public class DeleteProjectUseCase : IHandle<DeleteProjectRequest, ProjectResponse>
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;

        public DeleteProjectUseCase(IProjectRepository repository, IUserRepository userRepository)
        {
            _projectRepository = repository;
            _userRepository = userRepository;
        }
        public async Task<ProjectResponse> HandleAsync(DeleteProjectRequest request)
        {
            var project = await _projectRepository.DeleteAsync(request.ProjectId, request.UserId);
            await _userRepository.DeleteProjectAsync(request.ProjectId, request.UserId);
            return project.ToResponse();
        }
    }
}
