using MediatR;
using Shared.Common.SharedModels;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.TaskItems.Queries
{
    public class GetTaskItemsPageQuery : IRequest<PagedResult<TaskItemDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        public string? Search { get; set; }

        public GetTaskItemsPageQuery(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            SortBy = sortBy;
            SortDirection = sortDirection;
            Search = search;
        }
    }
}
