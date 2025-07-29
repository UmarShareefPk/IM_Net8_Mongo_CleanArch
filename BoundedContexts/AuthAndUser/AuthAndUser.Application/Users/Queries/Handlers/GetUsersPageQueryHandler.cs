using AuthAndUser.Application.DTOs;
using AuthAndUser.Application.Users.Commands;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Repositories;
using MediatR;
using Shared.Common.SharedModels;

namespace AuthAndUser.Application.Users.Commands.Handlers
{
    public class GetUsersPageQueryHandler : IRequestHandler<GetUsersPageQuery, PagedResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersPageQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<User>> Handle(GetUsersPageQuery request, CancellationToken cancellationToken)
        {            
            var (users, total) =  await _userRepository.GetUsersPageAsync(
                                            request.PageSize,
                                            request.PageNumber,
                                            request.SortBy,
                                            request.SortDirection,
                                            request.Search                                           
                                        );
            return new PagedResult<User> { TotalCount = total, Items = users };
        }
    }
}
