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
    public class MessageRepositoryTest
    {
        [Fact]
        public async void Add_Get_AsyncTest()
        {

            var boardRepository = appTestDependencyHelper.drawingBoardRepository;
            var projectRepository = appTestDependencyHelper.projectRepository;
            var chatRepository = appTestDependencyHelper.chatRepository;
            var messageRepository = appTestDependencyHelper.messageRepository;

            A.Configure<ProjectModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.DrawingBoards, () => {
                  return new List<DrawingBoardModel>();
              });

            var project = A.New<ProjectModel>();
            project = await projectRepository.AddAsync(project);

            A.Configure<DrawingBoardModel>()
              .Fill(c => c.Id, () => { return null; })
              .Fill(c => c.Chat, () => {
                  return new ChatModel();
              });

            var board = A.New<DrawingBoardModel>();
            board = await boardRepository.AddAsync(board, project.Id);

            A.Configure<ChatModel>()
             .Fill(c => c.Id, () => { return null; })
                .Fill(c => c.Messages, () => {
                    return new List<MessageModel>();
                });

            var chat = A.New<ChatModel>();
            chat = await chatRepository.AddAsync(chat, board.Id);

            A.Configure<MessageModel>()
             .Fill(c => c.Id, () => { return null; });
            // .Fill(c => c.UserID, () => { return null; });

            var messages = A.ListOf<MessageModel>(5);
            foreach(MessageModel message in messages)
                 await messageRepository.AddAsync(message, board.Id);

            board = await boardRepository.GetAsync(board.Id);

            //Assert.True(board.Chat.Messages.Count>0);

            var getMessages = await messageRepository.GetCollecionAsync(board.Id);

            for(int i=0;i<messages.Count;i++)
                Assert.Equal(getMessages.ToList()[i].UserID,messages[i].UserID);

        }


    }
}
