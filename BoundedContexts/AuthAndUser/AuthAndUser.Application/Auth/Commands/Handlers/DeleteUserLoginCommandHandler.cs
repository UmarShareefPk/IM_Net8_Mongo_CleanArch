using AuthAndUser.Application.Auth.Commands;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Commands.Handlers
{
    public class DeleteUserLoginCommandHandler : IRequestHandler<DeleteUserLoginCommand, bool>
    {
        private readonly IAuthRepository _repository;

        public DeleteUserLoginCommandHandler(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteUserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
