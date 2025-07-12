namespace WebApi
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
    public class UserDetailDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public List<string> Roles { get; set; }
    }
}
