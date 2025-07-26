using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands
{
    public record InsertUserLoginCommand(string UserId, string Username, string Password, string HubId)
     : IRequest<string>;
}
