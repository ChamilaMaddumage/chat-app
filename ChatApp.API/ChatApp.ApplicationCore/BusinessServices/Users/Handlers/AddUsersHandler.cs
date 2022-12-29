using ChatApp.ApplicationCore.BusinessServices.Users.Commands;
using ChatApp.ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.BusinessServices.Users.Handlers
{
    public class AddUsersHandler : IRequestHandler<AddUsersCommand, int>
    {
        private readonly IUsersService service;

        public AddUsersHandler(IUsersService service)
        {
            this.service = service;
        }

        public Task<int> Handle(AddUsersCommand command, CancellationToken cancellationToken)
        {
            return service.CreateUser(command.model);
        }
    }
}
