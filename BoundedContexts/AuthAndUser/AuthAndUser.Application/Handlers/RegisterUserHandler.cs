using AuthAndUser.Application.Commands;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {          
            return "";
        }
    }
}
