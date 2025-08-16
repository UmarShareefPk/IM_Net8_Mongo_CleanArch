using AuthAndUser.Domain.Entities;

namespace AuthAndUser.Application.DTOs
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public User? user { get; set; }
        public Team? Team { get; set; }
        public List<User> TeamUsers { get; set; } = new List<User>();
        public string Username { get; set; }        
        public string Token { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public int UnreadConversationCount { get; set; } = 0;
    }
}