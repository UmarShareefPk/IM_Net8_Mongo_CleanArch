using MediatR;


namespace AuthAndUser.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public string ProfilePic { get; set; } = string.Empty;
    }

}
