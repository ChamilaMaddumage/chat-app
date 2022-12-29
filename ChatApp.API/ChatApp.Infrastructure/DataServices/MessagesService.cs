using ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using ChatApp.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using ChatApp.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using ChatApp.Domain.Entities;

namespace ChatApp.Infrastructure.DataServices
{
    public class MessagesService : IMessagesService
    {
        private readonly ChatAppContext dbContext;

        public MessagesService(ChatAppContext context)
        {
            this.dbContext = context;
        }

        public async Task<int> CreateMessage(MessagesRequestModel requestModel)
        {
            return await Task.Run(() =>
            {
                Message message = new Message
                {
                    MessageContent = requestModel.MessageContent,
                    MessageBy = requestModel.MessageBy,
                    MessageDateAndTime = requestModel.MessageDateAndTime,
                    IsDeleted = false,
                    ChatRoomId = 1
                };

                var saveObject = dbContext.Messages.Add(message);
                dbContext.SaveChanges();

                return saveObject.Entity.MessageId;
            });
        }

        public async Task<MessagesByChatRoomIdResponseModel> GetMessagesByChatRoomId(int chatRoomId)
        {
            MessagesByChatRoomIdResponseModel messagesByChatRoomIdResponseModel = new MessagesByChatRoomIdResponseModel();

            messagesByChatRoomIdResponseModel.MessagesDTOs =
                await (from message in dbContext.Messages
                       join user in dbContext.Users on message.MessageBy equals user.UserId
                       where message.ChatRoomId == chatRoomId && message.IsDeleted == false
                       select new MessagesDTO
                       {
                           MessageId = message.MessageId,
                           MessageContent = message.MessageContent,
                           MessageDateAndTime = message.MessageDateAndTime,
                           MessageBy = user.DisplayName,
                           ChatRoomId = message.ChatRoomId,
                           UserId = user.UserId
                       }).ToListAsync();

            return messagesByChatRoomIdResponseModel;
        }
    }
}
