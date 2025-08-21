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
        public string? Status { get; set; }
        public string? UserId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string TeamId { get; set; } = string.Empty;

        public GetTaskItemsPageQuery(int pageSize, int pageNumber, string? sortBy, string? sortDirection, string? search, 
            string? status, string? userId, string? fromDate, string? toDate, string teamId)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            SortBy = sortBy;
            SortDirection = sortDirection;
            Search = search;
            Status = status;
            UserId = userId;
            FromDate = fromDate;
            ToDate = toDate;
            TeamId = teamId;
        }
    }
}
