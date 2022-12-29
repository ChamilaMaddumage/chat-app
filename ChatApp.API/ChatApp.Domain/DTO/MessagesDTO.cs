using System;

namespace ChatApp.Domain.DTO
{
    public class MessagesDTO
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public string MessageBy { get; set; }
        public DateTime MessageDateAndTime { get; set; }
        public bool IsDeleted { get; set; }
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
    }
}
