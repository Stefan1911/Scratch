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
                UserIDs = projectModel.UserIDs
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
    }

}