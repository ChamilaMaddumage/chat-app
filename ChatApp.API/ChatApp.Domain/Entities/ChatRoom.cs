using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities
{
    [Table("ChatRoom")]
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}