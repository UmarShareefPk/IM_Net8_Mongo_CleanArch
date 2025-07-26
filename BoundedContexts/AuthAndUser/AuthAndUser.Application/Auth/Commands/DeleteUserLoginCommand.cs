using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands
{
    public record DeleteUserLoginCommand(string Id) : IRequest<bool>;
}
