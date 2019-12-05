using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using Scratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Extensions
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateExampleRequst,ExampleResponse> handle,
            [FromBody]ExampleModel exampleModel)
        {
            var request = new CreateExampleRequst
            {
                Data1 = exampleModel.Data1,
                Data2 = exampleModel.Data2
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetExampleCollecionRequest, CollectionResponse<ExampleResponse>> handle)
        {
            var request = new GetExampleCollecionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
    }
}
