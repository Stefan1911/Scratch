﻿using Boundary.ChatContext.Request;
using Boundary.ChatContext.Response;
using Business.Models;
using Kernel;
using Kernel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IHandle<CreateChatRequest, ChatResponse> handle,
               [FromBody]ChatModel chatModel)
        {
            var request = new CreateChatRequest();
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHandle<GetChatCollectionRequest, CollectionResponse<ChatResponse>> handle)
        {
            var request = new GetChatCollectionRequest();
            var response = await handle.HandleAsync(request);

            return Ok(response);
        }

    }
}