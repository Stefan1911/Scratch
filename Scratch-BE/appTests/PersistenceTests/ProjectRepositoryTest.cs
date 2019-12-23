using System;
using System.Collections.Generic;
using System.Text;
using GenFu;
using System.Collections.Generic;
using Business.Models;
using Persistence.Repositories;
using Persistence.DataAccess;
using Xunit;
namespace appTests.PersistenceTests
{
    public class ProjectRepositoryTest
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
            var projectRepository = new ProjectRepository(dataAccess);
            
            var project = A.New<ProjectModel>();
              project.Id = null;
            
             project = await projectRepository.AddAsync(project);

            var getProject = await projectRepository.GetAsync(project.Id);

            Assert.Equal(project.Id, getProject.Id);
            
        }

        [Fact]
        public async void GetCollecionAsyncTest()
        {

            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var projectRepository = new ProjectRepository(dataAccess);

            var project = A.New<ProjectModel>();
            project.Id = null;

            project = await projectRepository.AddAsync(project);

            var getProject = await projectRepository.GetCollecionAsync();

            Assert.NotNull(getProject);

        }

    }
}