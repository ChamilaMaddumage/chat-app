using ChatApp.ApplicationCore.BusinessServices.Users.Commands;
using ChatApp.ApplicationCore.BusinessServices.Users.Commands.RequestModels;
using ChatApp.ApplicationCore.BusinessServices.Users.Queries;
using ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<int> CreateUser(UserDetailsRequestModel model)
        {
            return await mediator.Send(new AddUsersCommand(model));
        }

        [HttpGet]
        [Route("is-user-exists/{userName}")]
        public async Task<IsUserExistsResponseModel> IsUserExists([FromRoute]string userName)
        {
            return await mediator.Send(new IsUserExistsQuery(userName));
        }
    }
}
