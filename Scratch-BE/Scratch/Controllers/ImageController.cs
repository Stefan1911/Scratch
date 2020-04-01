using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Boundary.ImageContext.Request;
using Boundary.ImageContext.Response;
using Kernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices]IHandle<UploadImageRequest,UploadImageResponse> handle,
            [FromForm] IFormFile file)
        {
            
            var request = new UploadImageRequest{
                fileStream = file.OpenReadStream()
            };
            var response = await handle.HandleAsync(request);
            return Ok(response);
        }
    }   
}