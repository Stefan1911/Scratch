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
    public class UserRepositoryTest
    {
		
        [Fact]
        public async void getUserAsyncTest()
        {
            //Given
            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var userRepository = new UserRepository(dataAccess);
            //When
            var users = new UserModel
            {
                Name = "Ime",
                Username = "username",
                Password = "pass",
                PictureUrl = ""
            };

            UserModel use = await userRepository.AddAsync(users);
            UserModel used = await userRepository.GetAsync(use.Id);
            //Then
            Assert.Equal(use.Id, used.Id);
            
        }

        [Fact]
        public async void addUserRangeAsyncTest()
        {
            //Given
            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var userRepository = new UserRepository(dataAccess);
            //When
            var users = A.ListOf<UserModel>();
            foreach (UserModel user in users)
            {
                user.Id = null;
            }

            var users2 = await userRepository.AddRangeAsync(users);
            //Then
            foreach (UserModel user in users2)
            {
                Assert.NotNull(user.Id);
            }

        }

        [Fact]
        public async void getCollectionAsyncTest()
        {
            //Given
            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var userRepository = new UserRepository(dataAccess);
            //When
            var users = A.ListOf<UserModel>();
            foreach (UserModel user in users)
            {
                user.Id = null;
            }

            var users2 = await userRepository.AddRangeAsync(users);
            //Then
            foreach (UserModel user in users2)
            {
                Assert.NotNull(user.Id);
            }

            var users3 = await userRepository.GetCollecionAsync();

            foreach (UserModel user in users3)
            {
                Assert.NotNull(user.Id);
            }

        }

        [Fact]
        public async void getRangeAsyncTest()
        {
            //Given
            var databaseSettings = this.GetDatabaseSettings();
            var dataAccess = new DatabaseContext(databaseSettings);
            var userRepository = new UserRepository(dataAccess);
            //When
            var usersWithNullId = A.ListOf<UserModel>();
            foreach (UserModel user in usersWithNullId)
            {
                user.Id = null;
            }

            var usersToAdd = await userRepository.AddRangeAsync(usersWithNullId);
            var listId = new List<string>();

            foreach (UserModel user in usersToAdd)
            {
                listId.Add(user.Id);
            }
            
            var getUsers = await userRepository.GetRangeAsync(listId);

            var count = 0;
            foreach (UserModel user in getUsers)
            {
                Assert.Equal(user.Id,listId[count++] );
            }

        }

        private DatabaseSettings GetDatabaseSettings()
        {
            return Scratch.Startup.GetApplicationConfiguration();
        }

    }
}