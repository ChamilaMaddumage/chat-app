using ChatApp.ApplicationCore.BusinessServices.Users.Commands.RequestModels;
using ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels;
using System.Threading.Tasks;

namespace ChatApp.ApplicationCore.Interfaces
{
    public interface IUsersService : IBaseChatApp
    {
        Task<int> CreateUser(UserDetailsRequestModel requestModel);
        Task<IsUserExistsResponseModel> IsUserExists(string userName);
    }
}
