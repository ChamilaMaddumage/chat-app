using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.Interfaces
{
    public interface IChatRoomsService : IBaseChatApp
    {
        Task<ChatRoomsByUserIdResponseModel> GetChatRoomsByUserId(int userId);
    }
}
