using ChatApp.ApplicationCore.BusinessServices.Users.Commands.RequestModels;
using MediatR;

namespace ChatApp.ApplicationCore.BusinessServices.Users.Commands
{
    public record AddUsersCommand(UserDetailsRequestModel model) : IRequest<int>;
}
