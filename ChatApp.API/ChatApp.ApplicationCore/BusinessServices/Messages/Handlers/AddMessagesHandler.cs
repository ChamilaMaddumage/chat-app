using ChatApp.ApplicationCore.BusinessServices.Messages.Commands;
using ChatApp.ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.BusinessServices.Messages.Handlers
{
    class AddMessagesHandler : IRequestHandler<AddMessagesCommand, int>
    {
        private readonly IMessagesService service;

        public AddMessagesHandler(IMessagesService service)
        {
            this.service = service;
        }

        public Task<int> Handle(AddMessagesCommand command, CancellationToken cancellationToken)
        {
            return service.CreateMessage(command.model);
        }
    }
}
