using MediatR;
using Shared.Common.Enums;

namespace TaskManagement.Application.TaskItems.Commands
{
    public record CreateTaskItemCommand(
        string Title, 
        string Description, 
        TaskItemPriority Priority,
        DateTime DueDate,
        string AssignedTo) : IRequest<string>;
}
