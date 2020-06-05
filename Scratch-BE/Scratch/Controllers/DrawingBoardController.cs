using Boundary.DrawingBoardContext.Request;
using Boundary.ShapeContext.Response;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using Scratch.Models;
using System.Threading.Tasks;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingBoardController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateDrawingBoardRequest, DrawingBoardResponse> handle,
            [FromBody]DrawingBoardModel drawingBoard)
        {
            var request = new CreateDrawingBoardRequest(){
				ProjectId = drawingBoard.ProjectId,
                Name = drawingBoard.Name,
                ExcludedClientId = drawingBoard.ExcludedClientId
			};
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetDrawingBoardCollectionRequest,CollectionResponse<DrawingBoardResponse>> handle
			,string projectId)
        {
            var request = new GetDrawingBoardCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }

		[HttpGet("{projectId}/{boardId}")]
        public async Task<IActionResult> Get([FromServices] IHandle<GetDrawingBoardRequest,DrawingBoardResponse> handle
			,string projectId,string boardId)
        {
            var request = new GetDrawingBoardRequest(){
				projectId = projectId,
				boardId = boardId
			};
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
        [HttpPatch]
        public async Task<IActionResult> RenameTable([FromServices] IHandle<RenameDrawingBoardRequest, DrawingBoardResponse> handle,
             [FromBody]DrawingBoardRenameModelcs drawingBoard)
        {
            var request = new RenameDrawingBoardRequest()
            {
                TableId = drawingBoard.TableId,
                Name = drawingBoard.Name,
                ProjectId=drawingBoard.ProjectId
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }
        [HttpDelete("{projectId}/{tableId}")]
        public async Task<IActionResult> Delete([FromServices] IHandle<DeleteDrawingBoardRequest, DrawingBoardResponse> handle,
           string projectId, string tableId)
        {
            var request = new DeleteDrawingBoardRequest()
            {
                ProjectId= projectId,
                TableId = tableId
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }
    }
}