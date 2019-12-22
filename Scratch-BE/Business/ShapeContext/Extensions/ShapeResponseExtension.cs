using System;
using System.Collections.Generic;
using System.Text;
using Boundary.UserContext.Response;
using Business.Models;

namespace Business.UserContext.Extension
{
    public static class ShapeResponseExtension
    {
        public static ShapeResponse ToResponse(this ShapeModel shape)
        {
            return new ShapeResponse
            {
                Id = shape.Id,
                FillColor = shape.FillColor,
                StrockColor = shape.StrockColor,
                Type = shape.Type
               
            };
        }
    }
}
