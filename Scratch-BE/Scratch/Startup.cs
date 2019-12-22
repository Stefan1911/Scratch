using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Boundary.UserContext;
using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.Contracts;
using Business.ExampleContext.UseCases;
using Business.UserContext.UseCases;
using Kernel.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.DataAccess;
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
            services.AddSingleton<DatabaseContext>();
            #region Shape
            services.AddSingleton<IShapeRepository, ShapeRepository>();
            services.AddUseCase<CreateShapeRequest, ShapeResponse, CreateShapeUseCase>();
            #endregion
            #region Message
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddUseCase<CreateMessageRequest, MessageResponse, CreateMessageUseCase>();
            #endregion
            #region DrawingBoard
            services.AddSingleton<IDrawingBoardRepository, DrawingBoardRepository>();
            services.AddUseCase<CreateDrawingBoardRequest, DrawingBoardResponse, CreateDrawingBoardUseCase>();
            #endregion
            #region Project
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddUseCase<CreateProjectRequest, ProjectResponse, CreateProjectUseCase>();
            #endregion
            #region User
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddUseCase<CreateUserRequest, UserResponse, CreateUserUseCase>();
            services.AddUseCase<GetUserCollectionRequest, CollectionResponse<UserResponse>, GetUserCollectionUseCase > ();
            #endregion
            #region Example
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
