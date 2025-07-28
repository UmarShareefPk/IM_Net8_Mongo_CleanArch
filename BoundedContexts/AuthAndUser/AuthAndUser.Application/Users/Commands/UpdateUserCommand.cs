using MediatR;
using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public string ProfilePic { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Moderator;
        public bool IsActive { get; set; } = true;       
    }

}
