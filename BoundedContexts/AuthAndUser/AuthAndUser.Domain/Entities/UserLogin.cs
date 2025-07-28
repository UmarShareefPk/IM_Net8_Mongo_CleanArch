
namespace AuthAndUser.Domain.Entities
{
    public class UserLogin
    {
        public string? Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string HubId { get; set; } = null!;
        public DateTime CreateDate { get; set; }

    }
}