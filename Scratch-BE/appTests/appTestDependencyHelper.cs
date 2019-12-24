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

		private static DatabaseSettings GetDatabaseSettings()
        {
            return Scratch.Startup.GetApplicationConfiguration();
        }
    }
}