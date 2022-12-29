using ChatApp.Domain.DTO;
using System.Collections.Generic;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels
{
    public class MessagesByChatRoomIdResponseModel
    {
        public List<MessagesDTO> MessagesDTOs { get; set; }
    }
}
