namespace ChatApp.ApplicationCore.BusinessServices.Users.Queries.ResponseModels
{
    public class IsUserExistsResponseModel
    {
        public bool IsUserExists { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
