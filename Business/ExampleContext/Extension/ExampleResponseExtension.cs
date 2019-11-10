using Boundary.ExampleContext.Response;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExampleContext.Extension
{
    public static class ExampleResponseExtension
    {
        public static ExampleResponse ToResponse(this Example example)
        {
            return new ExampleResponse
            {
                Id = example.Id,
                Data1 = example.Data1,
                Data2 = example.Data2
            };
        }
    }
}
