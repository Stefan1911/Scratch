using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Business.Contracts;
using Business.ExampleContext.UseCases;
using Kernel.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Repositories;
using Scratch.Extensions;

namespace Scratch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region
            services.AddSingleton<IExampleRepository, ExampleRepository>();
            services.AddUseCase<CreateExampleRequst, ExampleResponse, CreateExampleUseCase>();
            services.AddUseCase<GetExampleCollecionRequest, CollectionResponse<ExampleResponse>, GetExampleCollectionUseCase>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
