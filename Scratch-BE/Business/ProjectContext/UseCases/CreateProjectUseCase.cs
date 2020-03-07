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
                Description=request.Description,
                DrawingBoards=new List<DrawingBoardModel>(),
                PictureUrl=request.PictureUrl,
                UserIDs = request.UserIDs
            };
            var returnProject = await _projectRepository.AddAsync(project);

            await _userRepository.UpdateRangeAsync(request.UserIDs, project.Id );
            return returnProject.ToResponse();
        }

    }
}
