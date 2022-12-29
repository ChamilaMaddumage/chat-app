using ChatApp.Domain.DTO;
using System.Collections.Generic;

namespace ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels
{
    public class ChatRoomsByUserIdResponseModel
    {
        public List<ChatRoomDetailsDTO> ChatRoomDetailsDTOs { get; set; }
    }
}
