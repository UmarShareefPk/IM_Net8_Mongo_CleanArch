using AuthAndUser.Application.Auth.Commands;
using AuthAndUser.Application.Security;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands.Handlers
{
    public class InsertUserLoginCommandHandler : IRequestHandler<InsertUserLoginCommand, string>
    {
        private readonly IAuthRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        public InsertUserLoginCommandHandler(IAuthRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(InsertUserLoginCommand request, CancellationToken cancellationToken)
        {
            _passwordHasher.CreateHash(request.Password, out byte[] hash, out byte[] salt);

            var entity = new UserLogin
            {
                UserId = request.UserId,
                Username = request.Username,
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = Convert.ToBase64String(salt),
                HubId = request.HubId,
                CreateDate = DateTime.UtcNow
            };

            await _repository.InsertAsync(entity);
            return entity.Id!;
        }
    }   


}
