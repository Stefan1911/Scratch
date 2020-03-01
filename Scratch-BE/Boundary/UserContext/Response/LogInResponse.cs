using Kernel.Response;

namespace Boundary.UserContext.Response
{
    public class LogInResponse : IResponseContext
    {
        public UserResponse User { get; set; }
        public bool UsernameIncorrect { get; set; }

    }
}