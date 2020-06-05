using System.Threading.Tasks;
using Business.Contracts;
using Business.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessagingService
{
	public class DrawingBoardMessageBroker : IDrawingBoardMessageBroker
	{
		private IHubContext<DrawingBoardHub> _messagingHub;
		public DrawingBoardMessageBroker(IHubContext<DrawingBoardHub> messagingHub)
		{
			_messagingHub = messagingHub;
		}

		public async Task AddDrawingBoard(string MessageName, string excludedClientID, DrawingBoardModel drawingBoard)
		{
			await _messagingHub.Clients.AllExcept(excludedClientID).SendAsync(MessageName + "/add", drawingBoard);
		}

		public async Task DeleteDrawingBoard(string MessageName, string boardId)
		{
			await _messagingHub.Clients.All.SendAsync(MessageName + "/delete", boardId);
		}

		public async Task DeleteShapeAsync(string MessageName, string excludedClientID, string shapeId)
		{
			await _messagingHub.Clients.AllExcept(excludedClientID).SendAsync(MessageName + "/deleteShape", shapeId);
		}
		public async Task RenameDrawingBoard(string ProjectId, string TableId, string Name)
		{
			await _messagingHub.Clients.All.SendAsync(ProjectId + "/rename",new { 
				Name=Name,
				TableId=TableId
			});
		}

		public async Task PushShapeAsync(string MessageName, string excludedClientId,ShapeModel shape)
		{
			await _messagingHub.Clients.AllExcept(excludedClientId).SendAsync(MessageName,shape);
		}

		public async Task UpdateShapeAsync(string MessageName, string excludedClientID, int shapeIndex, ShapeModel ShapeModel)
		{
			await _messagingHub.Clients.AllExcept(excludedClientID).SendAsync(MessageName+"/updateShape",ShapeModel,shapeIndex);
		}

	}
}