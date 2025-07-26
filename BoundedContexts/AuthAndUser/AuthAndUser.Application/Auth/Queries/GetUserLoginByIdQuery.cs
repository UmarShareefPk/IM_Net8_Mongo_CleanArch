using AuthAndUser.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Application.Auth.Queries
{
    public class GetUserLoginByIdQuery : IRequest<UserLogin?>
    {
        public string Id { get; set; } = null!;
    }

}
