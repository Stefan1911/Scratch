using Xunit;
using Microsoft.Extensions.Configuration;
using Persistence.DataAccess;
using Scratch;
using GenFu;
using Business.Models;
using Persistence.Repositories;
using Moq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace appTests.PersistenceTests	
{
    public class UserRepositoryTest
    {
		[Fact]
		public async void addUserAsyncTest()
		{
			//Given
			var newUserID = "randomString";
			var IMongoCollecionMock = new Mock<IMongoCollection<UserModel>>();
			IMongoCollecionMock
							.Setup(collecion => collecion.InsertOneAsync(It.IsAny<UserModel>(),It.IsAny<InsertOneOptions>(),It.IsAny<CancellationToken>()))
							.Returns((UserModel userModel,InsertOneOptions options,CancellationToken token) => {
									var task = new Task(() => {userModel.Id = newUserID;});
									return Task.FromResult(task);
									}
							);
			var service = new Mock<DatabaseContext>();
			service
				.Setup(x => x.Users).Returns(IMongoCollecionMock.Object);
			var userrRepository = new UserRepository(service.Object);
			var faceUser = A.New<UserModel>();
			faceUser.Id = null;
		//When
			var newUser = await userrRepository.AddAsync(faceUser);

		//Then
			Assert.Equal(newUser.Id,newUserID);
		}

		private DatabaseSettings GetDatabaseSettings(){
			return Scratch.Startup.GetApplicationConfiguration();
		}
    }
}