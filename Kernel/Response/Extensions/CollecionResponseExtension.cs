using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Response.Extensions
{
    public static class CollecionResponseExtension
    {
        public static CollectionResponse<T> ToCollecionResponse<T>(this IEnumerable<T> collecion)
            where T : class, IResponseContext
        {
            var resaultCollecion = new CollectionResponse<T>();
            resaultCollecion.AddRange(collecion);

            return resaultCollecion;
        }

    }
}
