using ChatApp.ApplicationCore.BusinessServices.Messages.Commands;
using ChatApp.ApplicationCore.BusinessServices.Messages.Commands.RequestModels;
using ChatApp.ApplicationCore.BusinessServices.Messages.Queries;
using ChatApp.ApplicationCore.BusinessServices.Messages.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MessagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get-messages-by-chat-room-id/{chatRoomId}")]
        public async Task<MessagesByChatRoomIdResponseModel> GetMessagesByChatRoomAsync([FromRoute]int chatRoomId)
        {
            return await mediator.Send(new GetMessagesByChatRoomIdQuery(chatRoomId));
        }

        [HttpPost]
        [Route("create-message")]
        public async Task<int> CreateMessage(MessagesRequestModel model)
        {
            return await mediator.Send(new AddMessagesCommand(model));
        }
    }
}
