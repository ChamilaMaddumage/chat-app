using ChatApp.ApplicationCore.BusinessServices.Messages.Queries;
using ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Handlers
{
    public class GetMessagesByChatRoomIdHandler : IRequestHandler<GetMessagesByChatRoomIdQuery, MessagesByChatRoomIdResponseModel>
    {
        private readonly IMessagesService service;

        public GetMessagesByChatRoomIdHandler(IMessagesService service)
        {
            this.service = service;
        }

        public async Task<MessagesByChatRoomIdResponseModel> Handle(GetMessagesByChatRoomIdQuery request, CancellationToken cancellationToken)
        {
            return await service.GetMessagesByChatRoomId(request.chatRoomId);
        }
    }
}
