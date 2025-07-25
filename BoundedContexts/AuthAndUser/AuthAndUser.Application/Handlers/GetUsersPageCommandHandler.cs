using AuthAndUser.Application.Commands;
using AuthAndUser.Domain.Interfaces;
using AuthAndUser.Domain.Models;
using MediatR;

namespace AuthAndUser.Application.Handlers
{
    public class GetUsersPageCommandHandler : IRequestHandler<GetUsersPageCommand, UsersWithPage>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersPageCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersWithPage> Handle(GetUsersPageCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersPageAsync(
                request.PageSize,
                request.PageNumber,
                request.SortBy,
                request.SortDirection,
                request.Search
            );
        }
    }
}
