using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.Response
{
    public class CollectionResponse<T> : List<T>,ICollectionResponseContext 
        where T : IResponseContext
    {
    }
}
