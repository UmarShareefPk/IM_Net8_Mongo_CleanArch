using AuthAndUser.Application.Users.Queries;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Users.Queries.Handlers
{
    public class GetAllTeamUsersQueryHandler : IRequestHandler<GetAllTeamUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository;

        public GetAllTeamUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle(GetAllTeamUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllTeamUsersAsync(request.TeamId);
        }
    }

}
