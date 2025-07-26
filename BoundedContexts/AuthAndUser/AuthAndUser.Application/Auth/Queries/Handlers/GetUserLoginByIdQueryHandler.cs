using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Queries.Handlers
{
    public class GetUserLoginByIdQueryHandler : IRequestHandler<GetUserLoginByIdQuery, UserLogin>
    {
        private readonly IAuthRepository _repository;

        public GetUserLoginByIdQueryHandler(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserLogin?> Handle(GetUserLoginByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }

}
