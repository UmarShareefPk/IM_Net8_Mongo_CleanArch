
using Shared.Common.Enums;


namespace AuthAndUser.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = null!;      
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ProfilePic { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public bool IsActive { get; set; } = true;
        public string teamId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
