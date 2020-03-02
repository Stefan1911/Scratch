using Kernel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boundary.UserContext
{
   public class CreateUserRequest : IRequestContext
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> ProjectIDs { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PictureUrl { get; set; }
    }
}
