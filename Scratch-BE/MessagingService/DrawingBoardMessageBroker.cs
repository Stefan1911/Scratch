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

		public async Task PushShape(string MessageName, ShapeModel shape)
		{
			await _messagingHub.Clients.All.SendAsync(MessageName,shape);
		}
	}
}