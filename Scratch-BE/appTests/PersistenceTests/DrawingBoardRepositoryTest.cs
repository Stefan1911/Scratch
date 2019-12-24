using Xunit;
using Microsoft.Extensions.Configuration;
using Persistence.DataAccess;
using Scratch;
using Business.Models;
using Persistence.Repositories;
using MongoDB.Driver;
using GenFu;
using System.Collections.Generic;
using System.Linq;

namespace appTests.PersistenceTests
{
    public class DrawingBoardRepositoryTest
    {
        private DatabaseSettings GetDatabaseSettings()
        {
            return Scratch.Startup.GetApplicationConfiguration();
        }

        [Fact]
        public async void AddAsyncTest()
        {
			var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var boardRepository = new DrawingBoardRepository(dataAccess);
            var projectRepository = new ProjectRepository(dataAccess);

            A.Configure<ProjectModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.DrawingBoards, () => {
                  return new List<DrawingBoardModel>();
              });
            var project = A.New<ProjectModel>();
            project = await projectRepository.AddAsync(project);
            A.Configure<DrawingBoardModel>()
              .Fill(c => c.Id, () => { return null; });
            var board = A.New<DrawingBoardModel>();

            board = await boardRepository.AddAsync(board,project.Id);
			project = await projectRepository.GetAsync(project.Id);
            Assert.NotNull(project.DrawingBoards.Where(_board => _board.Id.Equals(board.Id)).FirstOrDefault());
        }

    }
}
