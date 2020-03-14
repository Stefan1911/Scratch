using Business.Contracts;
using Business.Models;
using MessagingService.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessagingService
{
    public class ChatMessageBroker : IChatMessageBroker
	{
		private IHubContext<ChatHub> _messagingHub;
		public ChatMessageBroker(IHubContext<ChatHub> messagingHub)
		{
			_messagingHub = messagingHub;
		}

		public async Task AddChat(string MessageName, MessageModel message)
		{
			await _messagingHub.Clients.All.SendAsync(MessageName + "/chat/add", message);
		}
	}
}