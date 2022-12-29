using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries;
using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.BusinessServices.ChatRooms.Handlers
{
    public class GetChatRoomsByUserIdHandler : IRequestHandler<GetChatRoomsByUserIdQuery, ChatRoomsByUserIdResponseModel>
    {
        private readonly IChatRoomsService service;

        public GetChatRoomsByUserIdHandler(IChatRoomsService service)
        {
            this.service = service;
        }

        public async Task<ChatRoomsByUserIdResponseModel> Handle(GetChatRoomsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await service.GetChatRoomsByUserId(request.userId);
        }
    }
}
