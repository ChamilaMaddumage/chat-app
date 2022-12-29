using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Data
{
    public class ChatAppContext : DbContext
    {
        public ChatAppContext()
        { }

        public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options)
        { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatRoomDetail> ChatRoomDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Message>(entity =>
            //{
            //    entity.HasNoKey();
            //});
        }
    }
}
