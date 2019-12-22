using System;
using System.Collections.Generic;
using System.Text;
using Boundary.UserContext.Response;
using Business.Models;

namespace Business.UserContext.Extension
{
    public static class MessageResponseExtension
    {
        public static MessageResponse ToResponse(this MessageModel message)
        {
            return new MessageResponse
            {
                Id = message.Id,
                TimeStamp = message.TimeStamp,
                UserID = message.UserID
            };
        }
    }
}
