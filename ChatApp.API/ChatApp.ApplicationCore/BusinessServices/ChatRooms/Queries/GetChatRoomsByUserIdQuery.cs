using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels;
using MediatR;

namespace ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries
{
    public record GetChatRoomsByUserIdQuery(int userId) : IRequest<ChatRoomsByUserIdResponseModel>;
}
