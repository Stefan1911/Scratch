using Kernel.Request;

namespace Boundary.UserContext.Request
{
    public class LogInRequest : IRequestContext
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}