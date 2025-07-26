using AuthAndUser.Application.Auth.Commands;
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

        public InsertUserLoginCommandHandler(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(InsertUserLoginCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserLogin
            {
                UserId = request.UserId,
                Username = request.Username,
                Password = request.Password,
                HubId = request.HubId,
                CreateDate = DateTime.UtcNow
            };

            await _repository.InsertAsync(entity);
            return entity.Id!;
        }
    }   


}
