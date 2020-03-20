using Kernel.Request;

namespace Boundary.ShapeContext.Request
{
    public class DeleteShapeRequest : IRequestContext
    {
        public string TableId { get; set; }
        public string ShapeId { get; set; }
        public string ClientId { get; set; }
    }
}