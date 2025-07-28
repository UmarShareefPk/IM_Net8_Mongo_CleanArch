using AuthAndUser.Application.Users.Commands;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Users.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                ProfilePic = request.ProfilePic,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = request.IsActive,
                Role = request.Role
            };

            await _repository.InsertAsync(user);
            return user.Id;
        }
    }

}
