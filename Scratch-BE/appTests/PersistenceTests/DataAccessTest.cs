using Persistence.DataAccess;
using Persistence.Repositories;
using Xunit;

namespace appTests.PersistenceTests
{
    public class DattaAccessTest
    {
        [Fact]
        public void DataBaseConectionTest()
        {
			//setup
			var databaseSettings = this.GetDatabaseSettings();
			var dataAccess = new DatabaseContext(databaseSettings);
			var userrRepository = new UserRepository(dataAccess);
			//aserts
			
			Assert.NotNull(dataAccess);
        }

		private DatabaseSettings GetDatabaseSettings(){
			return Scratch.Startup.GetApplicationConfiguration();
		}
    }
}
