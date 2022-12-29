using ChatApp.ApplicationCore.BusinessServices.Users.Queries;
using ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.BusinessServices.Users.Handlers
{
    public class IsUserExistsHandler : IRequestHandler<IsUserExistsQuery, IsUserExistsResponseModel>
    {
        private readonly IUsersService service;

        public IsUserExistsHandler(IUsersService service)
        {
            this.service = service;
        }

        public async Task<IsUserExistsResponseModel> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
        {
            return await service.IsUserExists(request.userName);
        }
    }
}
