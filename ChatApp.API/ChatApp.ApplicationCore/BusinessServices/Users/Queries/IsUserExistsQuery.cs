using ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels;
using MediatR;

namespace ChatApp.ApplicationCore.BusinessServices.Users.Queries
{
    public record IsUserExistsQuery(string userName) : IRequest<IsUserExistsResponseModel>;
}
