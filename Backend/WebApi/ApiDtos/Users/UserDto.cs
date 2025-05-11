namespace WebApi.ApiDtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        // todo change to nickname, not username, which is an e-mail address
        public string UserName { get; set; }
    }
}
