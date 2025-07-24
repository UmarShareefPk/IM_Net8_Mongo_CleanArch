using AuthAndUser.Domain.Entities;

namespace AuthAndUser.Application.DTOs
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public User? user { get; set; }
        public string Username { get; set; }        
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLogin { get; set; }
        public int UnreadConversationCount { get; set; } = 0;
    }
}