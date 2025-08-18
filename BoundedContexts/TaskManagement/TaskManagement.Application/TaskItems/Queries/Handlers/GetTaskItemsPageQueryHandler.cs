using AutoMapper;
using MediatR;
using Shared.Common.SharedModels;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.TaskItems.Queries;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Application.TaskItems.Queries.Handlers
{
    public class GetTaskItemsPageQueryHandler : IRequestHandler<GetTaskItemsPageQuery, PagedResult<TaskItemDto>>
    {   
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetTaskItemsPageQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TaskItemDto>> Handle(GetTaskItemsPageQuery request, CancellationToken cancellationToken)
        {
            var (items, total) = await _taskItemRepository.GetTaskItemsPageAsync(
                request.PageSize,
                request.PageNumber,
                request.SortBy,
                request.SortDirection,
                request.Search, request.TeamId);

            var taskItemDtos = _mapper.Map<List<TaskItemDto>>(items);
        return new PagedResult<TaskItemDto> { TotalCount = total, Items = taskItemDtos };
        }
    }
}
