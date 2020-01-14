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

		public async Task PushShape(string MessageName, string excludedClientId,ShapeModel shape)
		{
			await _messagingHub.Clients.AllExcept(excludedClientId).SendAsync(MessageName,shape);
		}
	}
}