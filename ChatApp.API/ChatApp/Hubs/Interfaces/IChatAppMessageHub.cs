using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using System.Threading.Tasks;

namespace ChatApp.WebAPI.Hubs.Interfaces
{
    public interface IChatAppMessageHub
    {
        Task CreateMessageAsync(MessagesRequestModel messagesRequestModel);
    }
}
