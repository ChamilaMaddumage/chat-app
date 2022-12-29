using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries;
using ChatApp.ApplicationCore.BusinessServices.ChatRooms.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ChatRoomsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get-chat-rooms-by-user-id/{userId}")]
        public async Task<ChatRoomsByUserIdResponseModel> GetChatRoomsByUserIdAsync([FromRoute] int userId)
        {
            return await mediator.Send(new GetChatRoomsByUserIdQuery(userId));
        }
    }
}
