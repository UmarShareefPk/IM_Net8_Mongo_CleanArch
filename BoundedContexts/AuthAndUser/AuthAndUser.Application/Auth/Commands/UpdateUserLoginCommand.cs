using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands
{
    public record UpdateUserLoginCommand(string Id, string? Username, string? Password)
     : IRequest<bool>;
}
