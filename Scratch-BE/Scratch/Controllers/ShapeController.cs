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
				SenderClientId = shapeModel.sendingClientID,
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
                Id = shapeModel.Id,
                Index=shapeModel.ShapeIndex,
				SenderClientId = shapeModel.sendingClientID,
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

        [HttpDelete("{clientId}/{tableId}/{shapeId}")]
        public async Task<IActionResult> Delete([FromServices] IHandle<DeleteShapeRequest, NoResponse> handle,string tableId,string shapeId,string clientId)
        {
            var request = new DeleteShapeRequest{
                TableId = tableId,
                ShapeId = shapeId,
                ClientId = clientId
            };
            await handle.HandleAsync(request);
            return NoContent();
        }

    }
}