using ChatApp.ApplicationCore.BusinessServices.Users.Commands.RequestModels;
using ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels;
using ChatApp.ApplicationCore.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.DataServices
{
    public class UsersService : IUsersService
    {
        private readonly ChatAppContext dbContext;

        public UsersService(ChatAppContext context)
        {
            this.dbContext = context;
        }

        public async Task<int> CreateUser(UserDetailsRequestModel requestModel)
        {
            return await Task.Run(() =>
            {
                User user = new User
                {
                    UserName = requestModel.UserName,
                    DisplayName = requestModel.DisplayName,
                    IsDeleted = false
                };

                var saveObject = dbContext.Users.Add(user);
                dbContext.SaveChanges();

                return saveObject.Entity.UserId;
            });
        }

        public async Task<IsUserExistsResponseModel> IsUserExists(string userName)
        {
            IsUserExistsResponseModel isUserExistsResponseModel = new IsUserExistsResponseModel();

            var user = await dbContext.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();

            if(user != null)
            {
                isUserExistsResponseModel.IsUserExists = true;
                isUserExistsResponseModel.DisplayName = user.DisplayName;
                isUserExistsResponseModel.UserId = user.UserId;
            } else
            {
                isUserExistsResponseModel.IsUserExists = false;
            }

            return isUserExistsResponseModel;
        }
    }
}
