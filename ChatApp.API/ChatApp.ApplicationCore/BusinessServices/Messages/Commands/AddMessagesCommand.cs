using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using MediatR;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Commands
{
        public record AddMessagesCommand(MessagesRequestModel model) : IRequest<int>;
}
