using System;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels
{
    public class MessagesRequestModel
    {
        public string MessageContent { get; set; }
        public int MessageBy { get; set; }
        public DateTime MessageDateAndTime { get; set; }
        public int ChatRoomId { get; set; }
    }
}
