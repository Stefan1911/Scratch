using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Business.Contracts;
using Business.Models;
using Business.UserContext.Extension;
using Kernel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.UserContext.UseCases
{
    public class CreateProjectUseCase : IHandle<CreateProjectRequest, ProjectResponse>
    {
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;

        public CreateProjectUseCase(IProjectRepository repository,IUserRepository userRepository )
        {
            _projectRepository = repository;
            _userRepository = userRepository;
        }
        public async Task<ProjectResponse> HandleAsync(CreateProjectRequest request)
        {
            var project = new ProjectModel
            {
                Name = request.Name,
                UserIDs = request.UserIDs
            };
            var returnProject = await _projectRepository.AddAsync(project);

            IEnumerable<UserModel> users = await _userRepository.GetRangeAsync(request.UserIDs);
            users.Select(user => { user.ProjectIDs.Add(returnProject.Id); return user; });
            await _userRepository.AddRangeAsync(users);
            return returnProject.ToResponse();
        }

    }
}
