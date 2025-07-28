using AuthAndUser.Application.Auth.Commands;
using AuthAndUser.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands.Handlers
{
    public class UpdateUserLoginCommandHandler : IRequestHandler<UpdateUserLoginCommand, bool>
    {
        private readonly IAuthRepository _repository;

        public UpdateUserLoginCommandHandler(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserLoginCommand request, CancellationToken cancellationToken)
        {
            var userLogin = await _repository.GetByIdAsync(request.Id);
            if (userLogin == null) return false;

            if (!string.IsNullOrEmpty(request.Username))
                userLogin.Username = request.Username;

            //if (!string.IsNullOrEmpty(request.Password))
            //    userLogin.Password = request.Password;

            await _repository.UpdateAsync(userLogin);
            return true;
        }
    }

}
