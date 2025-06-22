namespace WebApi
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
}
