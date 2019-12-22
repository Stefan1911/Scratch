using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Kernel;
using Kernel.Response;
using Scratch.Models;
using Boundary.UserContext;
using Boundary.UserContext.Response;
using Business.Models;
using Boundary.UserContext.Request;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateUserRequest, UserResponse> handle,
            [FromBody]UserModel userModel)
        {
            var request = new CreateUserRequest
            {
                Name = userModel.Name,
                Password = userModel.Password,
                PictureUrl = userModel.PictureUrl,
                ProjectIDs = userModel.ProjectIDs

            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetUserCollectionRequest, CollectionResponse<UserResponse>> handle)
        {
            var request = new GetUserCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
    }
}