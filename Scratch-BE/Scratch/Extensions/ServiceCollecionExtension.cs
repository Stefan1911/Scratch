using Kernel;
using Kernel.Request;
using Kernel.Response;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Extensions
{
    public static class ServiceCollecionExtension
    {
        public static void AddUseCase<TRequestContext, TResponseContgext, TRequestHandle>(this IServiceCollection service, ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TRequestContext : class, IRequestContext
            where TResponseContgext : class, IResponseContext
            where TRequestHandle : class, IHandle<TRequestContext, TResponseContgext>
        {
            service.Add(new ServiceDescriptor(typeof(IHandle<TRequestContext,TResponseContgext>),
                typeof(TRequestHandle),
                lifetime));
        }
    }
}
