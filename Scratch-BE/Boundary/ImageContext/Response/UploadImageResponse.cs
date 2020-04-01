using Kernel.Response;

namespace Boundary.ImageContext.Response
{
    public class UploadImageResponse : IResponseContext
    {
        public string ImageId { get; set; }
    }
}