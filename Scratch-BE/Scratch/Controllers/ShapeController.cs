using Boundary.ShapeContext.Request;
using Boundary.ShapeContext.Response;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using Scratch.Models;
using System.Linq;
using System.Threading.Tasks;

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
				TableId = shapeModel.TableId,
                FillColor = shapeModel.FillColor,
                StrockColor = shapeModel.StrockColor,
                Type = shapeModel.Type,
				Points = shapeModel.Points.Select((point) => {
					return new CreatePointRequest{
						X = point.X,
						Y = point.Y
					};
				})
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IHandle<UpdateShapeRequest, ShapeResponse> handle,
            [FromBody]ShapeModel shapeModel)
        {
            var request = new UpdateShapeRequest
            {
                Index=shapeModel.Index,
                TableId = shapeModel.TableId,
                FillColor = shapeModel.FillColor,
                StrockColor = shapeModel.StrockColor,
                Type = shapeModel.Type,
                Points = shapeModel.Points.Select((point) => {
                    return new CreatePointRequest
                    {
                        X = point.X,
                        Y = point.Y
                    };
                })
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