namespace MoverAndStore.WebApp.Models
{
    public class LoginResponse
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
    }
}
