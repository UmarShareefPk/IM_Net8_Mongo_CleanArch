using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public string Id { get; set; } = null!;
    }

}
