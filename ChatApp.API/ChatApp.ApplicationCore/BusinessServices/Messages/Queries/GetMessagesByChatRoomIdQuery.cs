using ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels;
using MediatR;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Queries
{
    public record GetMessagesByChatRoomIdQuery(int chatRoomId) : IRequest<MessagesByChatRoomIdResponseModel>;

}
