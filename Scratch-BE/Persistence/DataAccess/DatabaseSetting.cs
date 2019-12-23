namespace Persistence.DataAccess
{
    public class DatabaseSettings
    {
		//General Settings
        public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public int ServerResponeWaitTime { get; set; }

		//Collecion Names
		public string UserCollecionName { get; set; }
		public string ProjectCollecionName { get; set; }
		
    }
}