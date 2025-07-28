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
    public class CreateTaskItemHandler : IRequestHandler<CreateTaskItemCommand, string>
    {
        private readonly ITaskItemRepository _repository;        

        public CreateTaskItemHandler(ITaskItemRepository repository)
        {
            _repository = repository;           
        }

        public async Task<string> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {                
                Title = request.Title,
                Description = request.Description,
                AssignedTo = request.AssignedTo,
                Status = TaskItemStatus.New,
                CreatedAt = DateTime.UtcNow,
                Priority = request.Priority,
                DueDate = request.DueDate,
            };

            await _repository.AddAsync(task, cancellationToken);
            return task.Id;
        }
    }
}
