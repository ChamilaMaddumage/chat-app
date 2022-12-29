namespace ChatApp.Domain.DTO
{
    public class ChatRoomDetailsDTO
    {
        public int ChatRoomDetailId { get; set; }
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}
