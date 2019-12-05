using Kernel.Request;
using Kernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kernel
{
    public interface IHandle<TRequestContext,TResponseContex>
        where TRequestContext : class, IRequestContext
        where TResponseContex : class, IResponseContext
    {
        Task<TResponseContex> HandleAsync(TRequestContext request);
    }
}
