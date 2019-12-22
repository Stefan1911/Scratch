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
    public class ShapeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateShapeRequest, ShapeResponse> handle,
            [FromBody]ShapeModel shapeModel)
        {
            var request = new CreateShapeRequest
            {
                FillColor = shapeModel.FillColor,
                StrockColor = shapeModel.StrockColor,
                Type = shapeModel.Type

            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetShapeCollectionRequest, CollectionResponse<ShapeResponse>> handle)
        {
            var request = new GetShapeCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
    }
}