using Persistence.DataAccess;
using Persistence.Repositories;

namespace appTests
{
    public static class appTestDependencyHelper
    {
        
			private static DatabaseContext dataAccess = new DatabaseContext(GetDatabaseSettings());
			public static UserRepository userRepository { 
									get { return new UserRepository(dataAccess);} 
									private set{} 
									}
			public static DrawingBoardRepository drawingBoardRepository { 
									get { return new DrawingBoardRepository(dataAccess);} 
									private set{} 
									}
			public static ProjectRepository projectRepository { 
									get { return new ProjectRepository(dataAccess);} 
									private set{} 
									}
			public static ShapeRepository shapeRepository { 
									get { return new ShapeRepository(dataAccess);} 
									private set{} 
									}

			public static ChatRepository chatRepository
			{
					get { return new ChatRepository(dataAccess); }
					private set { }
			}
			public static MessageRepository messageRepository
			{
					get { return new MessageRepository(dataAccess); }
					private set { }
			}



		private static DatabaseSettings GetDatabaseSettings()
        {
            return Scratch.Startup.GetDatabaseConfiguration();
        }
    }
}