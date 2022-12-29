using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.Interfaces
{
    public interface IMessagesService : IBaseChatApp
    {
        Task<MessagesByChatRoomIdResponseModel> GetMessagesByChatRoomId(int chatRoomId);
        Task<int> CreateMessage(MessagesRequestModel requestModel);
    }
}
