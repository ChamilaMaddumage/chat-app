using ChatApp.ApplicationCore.BusinessServices.Messages.Commands;
using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using ChatApp.ApplicationCore.Interfaces;
using ChatApp.WebAPI.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebAPI.Hubs
{
    public class ChatAppMessageHub : Hub
    {
        private readonly IMessagesService service;
        public ChatAppMessageHub(IMessagesService service)
        {
            this.service = service;
        }
        public async Task CreateMessageAsync(MessagesRequestModel messagesRequestModel)
        {
            await service.CreateMessage(new AddMessagesCommand(messagesRequestModel).model);
            await Clients.All.SendAsync("MessageBroadcaster", messagesRequestModel);
        }
    }
}
