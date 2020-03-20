using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boundary.ChatContext.Request;
using Boundary.ChatContext.Response;
using Boundary.DrawingBoardContext.Request;
using Boundary.ExampleContext.Request;
using Boundary.ExampleContext.Response;
using Boundary.MessageContext.Request;
using Boundary.MessageContext.Response;
using Boundary.ProjectContext.Request;
using Boundary.ProjectContext.Response;
using Boundary.ShapeContext.Request;
using Boundary.ShapeContext.Response;
using Boundary.UserContext;
using Boundary.UserContext.Request;
using Boundary.UserContext.Response;
using Business.ChatContext.UseCases;
using Business.Contracts;
using Business.DrawingBoardContext.UseCases;
using Business.ExampleContext.UseCases;
using Business.ProjectContext.UseCases;
using Business.ShapeContext.UseCases;
using Business.UserContext.UseCases;
using Kernel.Response;
using MessagingService;
using MessagingService.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence.DataAccess;
using Persistence.Repositories;
using Scratch.Extensions;
using Scratch.Models.ConfigurationModels;

namespace Scratch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
			_corsConfiguration = GetCorsConfiguration();
			_signalRConfig = GetSignalRConfiguration();
        }

        public IConfiguration Configuration { get; }
		public CorsConfiguration _corsConfiguration { get; set; }
		public SignalRConfiguration _signalRConfig { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
			var databaseSetting = GetDatabaseConfiguration();
			services.AddSingleton(databaseSetting);

            services.AddControllers();
            services.AddSingleton<DatabaseContext>();
            #region Shape
            services.AddSingleton<IShapeRepository, ShapeRepository>();
            services.AddUseCase<CreateShapeRequest, ShapeResponse, CreateShapeUseCase>();
            services.AddUseCase<UpdateShapeRequest, ShapeResponse, UpdateShapeUseCase>();
			services.AddUseCase<DeleteShapeRequest,NoResponse,DeleteShapeUseCase>();
			#endregion
			#region Chat
			services.AddSingleton<IChatRepository, ChatRepository>();
			services.AddUseCase<CreateChatRequest, ChatResponse, CreateChatUseCase>();
			services.AddUseCase<GetChatRequest, ChatResponse, GetChatUseCase>();
			#endregion
			#region Message
			services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddUseCase<CreateMessageRequest, MessageResponse, CreateMessageUseCase>();
			#endregion
			#region DrawingBoard
			services.AddSingleton<IDrawingBoardRepository, DrawingBoardRepository>();
            services.AddUseCase<CreateDrawingBoardRequest, DrawingBoardResponse, CreateDrawingBoardUseCase>();
			services.AddUseCase<GetDrawingBoardRequest, DrawingBoardResponse, GetDrawingBoardUseCase>();
            #endregion
            #region Project
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddUseCase<CreateProjectRequest, ProjectResponse, CreateProjectUseCase>();
			services.AddUseCase<GetUserProjectsRequest, CollectionResponse<ProjectResponse>, GetUserProjectsUseCase>();
			services.AddUseCase<GetProjectRequest, ProjectResponse, GetProjectUseCase>();
			services.AddUseCase<JoinProjectRequest, ProjectResponse, JoinProjectUseCase>();
			services.AddUseCase<DeleteProjectRequest, ProjectResponse, DeleteProjectUseCase>();
			#endregion
			#region User
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddUseCase<LogInRequest,LogInResponse,LogInUseCase>();
            services.AddUseCase<CreateUserRequest, UserResponse, CreateUserUseCase>();
			services.AddUseCase<UpdateUserRequest, UserResponse, UpdateUserUseCase>();
			services.AddUseCase<GetUserCollectionRequest, CollectionResponse<UserResponse>, GetUserCollectionUseCase > ();
            #endregion
            #region Example
            services.AddSingleton<IExampleRepository, ExampleRepository>();
            services.AddUseCase<CreateExampleRequst, ExampleResponse, CreateExampleUseCase>();
            services.AddUseCase<GetExampleCollecionRequest, CollectionResponse<ExampleResponse>, GetExampleCollectionUseCase>();
            #endregion
			#region SignalR
			services.AddSignalR();
			services.AddSingleton<IDrawingBoardMessageBroker,DrawingBoardMessageBroker>();
			services.AddSingleton<IChatMessageBroker, ChatMessageBroker>();
			#endregion

			services.AddCors(options =>
			{
				options.AddPolicy(_corsConfiguration.Name,
				builder =>
				{
					builder.WithOrigins(_corsConfiguration.Origins.ToArray())
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
				});
			});
			
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseCors(_corsConfiguration.Name);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
				endpoints.MapHub<DrawingBoardHub>(_signalRConfig.DrawingBoardHubAddres);
				endpoints.MapHub<ChatHub>(_signalRConfig.ChatHubAddress);
			});
        }
		public static IConfigurationRoot GetIConfigurationRoot()
		{            
			return new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: true)
				.AddEnvironmentVariables()
				.Build();
		}

		public static DatabaseSettings GetDatabaseConfiguration()
		{
			var configuration = new DatabaseSettings();

			var iConfig = GetIConfigurationRoot();

			iConfig
				.GetSection(nameof(DatabaseSettings))
				.Bind(configuration);

			return configuration;
		}
		public static CorsConfiguration GetCorsConfiguration()
		{
			var iConfig = GetIConfigurationRoot();
			var configuration = new CorsConfiguration();
			iConfig.GetSection(nameof(CorsConfiguration)).Bind(configuration);;

			return configuration;
		}

		public static SignalRConfiguration GetSignalRConfiguration()
		{
			var iConfig = GetIConfigurationRoot();
			var configuration = new SignalRConfiguration();
			iConfig.GetSection(nameof(SignalRConfiguration)).Bind(configuration);;

			return configuration;
		}
    }
}
