using Boundary.UserContext;
using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Models;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromServices] IHandle<CreateUserRequest, UserResponse> handle,
            [FromBody]UserModel userModel)
        {
            var request = new CreateUserRequest
            {
                Email = userModel.Email,
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password,
                PictureUrl = userModel.PictureUrl
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromServices] IHandle<LogInRequest, LogInResponse> handle,
            [FromBody]UserModel userModel)
        {
            var request = new LogInRequest
            {
                Username = userModel.Username,
                Password = userModel.Password
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IHandle<UpdateUserRequest, UserResponse> handle,
            [FromBody]UserModel userModel)
        {
            var request = new UpdateUserRequest
            {
                Id=userModel.Id,
                Email = userModel.Email,
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password,
                PictureUrl = userModel.PictureUrl
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