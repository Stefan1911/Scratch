using Boundary.UserContext.Response;
using Business.Models;
using Business.UserContext.Extension;
using Kernel.Response;
using Kernel.Response.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ChatContext.Extensions
{
    public static class ChatUsersResponseExtension
    {
        public static CollectionResponse<UserResponse> ToResponse(this IEnumerable<UserModel> users)
        {
            List<UserResponse> returnUsers = new List<UserResponse>();
            foreach (UserModel user in users)
            {
                returnUsers.Add(user.ToResponse());
            }

            return returnUsers.ToCollecionResponse();
        }
    }
}
