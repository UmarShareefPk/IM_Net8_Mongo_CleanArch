using AuthAndUser.Domain.Models;
using MediatR;

namespace AuthAndUser.Application.Commands
{
    public class GetUsersPageCommand : IRequest<UsersWithPage>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        public string? Search { get; set; }

        public GetUsersPageCommand(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            SortBy = sortBy;
            SortDirection = sortDirection;
            Search = search;
        }
    }
}
