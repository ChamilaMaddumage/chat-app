using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities
{
    [Table("ChatRoomDetail")]
    public class ChatRoomDetail
    {
        public int ChatRoomDetailId { get; set; }
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
