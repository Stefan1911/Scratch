using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DrawingBoardController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateDrawingBoardRequest, DrawingBoardResponse> handle,
            [FromBody]DrawingBoardModel dawingBoardModel)
        {
            var request = new CreateDrawingBoardRequest();
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetDrawingBoardCollectionRequest, CollectionResponse<DrawingBoardResponse>> handle)
        {
            var request = new GetDrawingBoardCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
    }
}