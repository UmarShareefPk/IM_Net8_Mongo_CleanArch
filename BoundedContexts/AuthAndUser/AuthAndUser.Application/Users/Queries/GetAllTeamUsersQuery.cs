using AuthAndUser.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Users.Queries
{
    public class GetAllTeamUsersQuery : IRequest<List<User>>
    {
        public string TeamId { get; set; } = null!;
    }

}
