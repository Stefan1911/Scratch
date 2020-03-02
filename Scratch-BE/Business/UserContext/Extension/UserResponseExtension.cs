using System;
using System.Collections.Generic;
using System.Text;
using Boundary.ExampleContext.Response;
using Boundary.UserContext.Response;
using Business.Models;

namespace Business.UserContext.Extension
{
    public static class UserResponseExtension
    {
        public static UserResponse ToResponse(this UserModel user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                PictureUrl=user.PictureUrl,
                ProjectIDs=user.ProjectIDs
            };
        }
    }
}
