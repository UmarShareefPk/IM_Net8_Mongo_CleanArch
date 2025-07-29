using MediatR;
using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.TaskItems.Commands
{
    public record UpdateTaskItemCommand(string Id, string Title, string Description,
        string AssignedTo, TaskStatus Status, TaskItemPriority Priority, DateTime DueDate) : IRequest;
}
