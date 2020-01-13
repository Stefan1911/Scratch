using Persistence.DataAccess;
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
			//aserts
			Assert.NotNull(dataAccess);
        }

		private DatabaseSettings GetDatabaseSettings(){
			return Scratch.Startup.GetDatabaseConfiguration();
		}
    }
}
