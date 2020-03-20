using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Models;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateProjectRequest, ProjectResponse> handle,
               [FromBody]ProjectModel projectModel)
        {
            var request = new CreateProjectRequest
            {
                Name = projectModel.Name,
                UserIDs = projectModel.UserIDs,
                Description=projectModel.Description,
                PictureUrl=projectModel.PictureUrl
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetProjectCollectionRequest, CollectionResponse<ProjectResponse>> handle)
        {
            var request = new GetProjectCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IHandle<GetProjectRequest, ProjectResponse> handle,string id)
        {
            var request = new GetProjectRequest{
                ProjectId = id
            };
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
        [HttpGet("userProjects/{userId}")]
        public async Task<IActionResult> GetUserProjects([FromServices] IHandle<GetUserProjectsRequest, CollectionResponse<ProjectResponse>> handle, string userId)
        {
            var request = new GetUserProjectsRequest()
            {
                UserId = userId
            };
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete([FromServices] IHandle<DeleteProjectRequest,ProjectResponse> handle, string projectId)
        {
            var request = new DeleteProjectRequest()
            {
                ProjectId = projectId
            };
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
        [HttpPut("join/{projectId}/{userId}")]
        public async Task<IActionResult> JoinProject([FromServices] IHandle<JoinProjectRequest, ProjectResponse> handle,
          string projectId, string userId)
        {
            var request = new JoinProjectRequest()
            {
                ProjectId = projectId,
                UserId = userId
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }
    }

}