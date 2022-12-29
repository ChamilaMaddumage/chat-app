using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public int MessageBy { get; set; }
        public DateTime MessageDateAndTime { get; set; }
        public bool IsDeleted { get; set; }
        public int ChatRoomId { get; set; }
    }
}
