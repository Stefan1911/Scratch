using System;
using System.Collections.Generic;
using System.Text;
using GenFu;
using Business.Models;
using Persistence.Repositories;
using Persistence.DataAccess;
using Xunit;
namespace appTests.PersistenceTests
{
    public class ProjectRepositoryTest
    {
        [Fact]
        public async void AddAndGetAsyncTest()
        {

            var projectRepository = appTestDependencyHelper.projectRepository;
          
            var project = A.New<ProjectModel>();
            project.Id = null;

            project = await projectRepository.AddAsync(project);

            var getProject = await projectRepository.GetAsync(project.Id);

            Assert.Equal(project.Id, getProject.Id);

        }

        [Fact]
        public async void GetCollecionAsyncTest()
        {
            var projectRepository = appTestDependencyHelper.projectRepository;

            var project = A.New<ProjectModel>();
            project.Id = null;

            project = await projectRepository.AddAsync(project);

            var getProject = await projectRepository.GetCollecionAsync();

            Assert.NotNull(getProject);

        }
        [Fact]
        public async void GetProjectOfUserAsyncTest()
        {
            var projectRepository = appTestDependencyHelper.projectRepository;
			 var userRepository = appTestDependencyHelper.userRepository;
            A.Configure<ProjectModel>()
                .Fill(c => c.Id, () => { return null; })
                .Fill(c => c.UserIDs, () => {
                    return new List<string>();                   
                });
            var project = A.New<ProjectModel>();
            
            project = await projectRepository.AddAsync(project);

           

            A.Configure<UserModel>()
                .Fill(c => c.Id, () => { return null; })
                .Fill(c => c.ProjectIDs, () => {
                    var list = new List<string>();
                    list.Add(project.Id);
                   return list;
                });

            var usersWithNullId = A.ListOf<UserModel>(10);
          
            var usersToAdd = await userRepository.AddRangeAsync(usersWithNullId);

            foreach (UserModel user in usersToAdd)
            {
                project.UserIDs.Add(user.Id);
            }
            foreach (UserModel user in usersToAdd)
            {
                Assert.Contains(project.Id, user.ProjectIDs);
            }

        }
    }
}