using System;
using Business.Models;
using Persistence.DataAccess;
using Persistence.Repositories;
using Xunit;

namespace appTests
{
    public class DattaAccessTest
    {
        [Fact]
        public void DataBaseConectionTest()
        {
			//setup
			var dataAccess = new DatabaseContext();
			//aserts
			Assert.NotNull(dataAccess);
        }
    }
}
