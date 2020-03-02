using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext.Response
{
   public class UserResponse : IResponseContext
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> ProjectIDs { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PictureUrl { get; set; }
    }
}
