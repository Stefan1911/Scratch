using System.IO;
using Kernel.Request;

namespace Boundary.ImageContext.Request
{
    public class UploadImageRequest : IRequestContext
    {
        public Stream fileStream { get; set; }
    }
}