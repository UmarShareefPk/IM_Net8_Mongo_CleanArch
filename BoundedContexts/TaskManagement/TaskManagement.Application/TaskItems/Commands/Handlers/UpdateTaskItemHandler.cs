using MediatR;
using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Application.TaskItems.Commands.Handlers
{
    public class UpdateTaskItemHandler : IRequestHandler<UpdateTaskItemCommand>
    {
        private readonly ITaskItemRepository _repository;
       

        public UpdateTaskItemHandler(ITaskItemRepository repository)
        {
            _repository = repository;
           
        }

        public async Task Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                AssignedTo = request.AssignedTo,
                Status = (TaskItemStatus)request.Status,
                Priority = request.Priority,
                DueDate = request.DueDate,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.UpdateAsync(task, cancellationToken);
        }
    }
}
