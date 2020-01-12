using Boundary.MessageContext.Request;
using Boundary.MessageContext.Response;
using Business.Models;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateMessageRequest, MessageResponse> handle,
            [FromBody]MessageModel messageModel)
        {
            var request = new CreateMessageRequest
            {
                TimeStamp = messageModel.TimeStamp,
                UserID = messageModel.UserID

            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetMessageCollectionRequest, CollectionResponse<MessageResponse>> handle)
        {
            var request = new GetMessageCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }
    }
}