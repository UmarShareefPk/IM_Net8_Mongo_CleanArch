using AuthAndUser.Application.Commands;
using AuthAndUser.Application.DTOs;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;

using MediatR;
using Shared.Common;

namespace AuthAndUser.Application.Handlers
{
    public class GetUsersPageCommandHandler : IRequestHandler<GetUsersPageCommand, PagedResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersPageCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<User>> Handle(GetUsersPageCommand request, CancellationToken cancellationToken)
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
