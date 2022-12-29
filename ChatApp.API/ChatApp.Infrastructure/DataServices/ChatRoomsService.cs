using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using ChatApp.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using ChatApp.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.DataServices
{
    public class ChatRoomsService : IChatRoomsService
    {
        private readonly ChatAppContext dbContext;

        public ChatRoomsService(ChatAppContext context)
        {
            this.dbContext = context;
        }

        public async Task<ChatRoomsByUserIdResponseModel> GetChatRoomsByUserId(int userId)
        {
            ChatRoomsByUserIdResponseModel chatRoomsByUserIdResponseModel = new ChatRoomsByUserIdResponseModel();

            chatRoomsByUserIdResponseModel.ChatRoomDetailsDTOs =
                await (from chatRoom in dbContext.ChatRooms
                       join chatRoomDetail in dbContext.ChatRoomDetails
                       on chatRoom.ChatRoomId equals chatRoomDetail.ChatRoomId
                       where chatRoomDetail.UserId == userId && chatRoom.IsDeleted == false
                       select new ChatRoomDetailsDTO
                       {
                           ChatRoomDetailId = chatRoomDetail.ChatRoomDetailId,
                           ChatRoomId = chatRoomDetail.ChatRoomId,
                           UserId = chatRoomDetail.UserId,
                           Name = chatRoom.Name
                       }).ToListAsync();

            return chatRoomsByUserIdResponseModel;
        }
    }
}
