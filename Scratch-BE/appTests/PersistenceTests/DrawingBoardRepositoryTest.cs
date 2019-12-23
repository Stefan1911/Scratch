using Xunit;
using Microsoft.Extensions.Configuration;
using Persistence.DataAccess;
using Scratch;
using Business.Models;
using Persistence.Repositories;
using MongoDB.Driver;
using GenFu;
using System.Collections.Generic;

namespace appTests.PersistenceTests
{
    public class DrawingBoardRepositoryTest
    {
        private DatabaseSettings GetDatabaseSettings()
        {
            return Scratch.Startup.GetApplicationConfiguration();
        }

        [Fact]
        public async void AddAndGetAsyncTest()
        {

            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var boardRepository = new DrawingBoardRepository(dataAccess);

          

        }

    }
}
