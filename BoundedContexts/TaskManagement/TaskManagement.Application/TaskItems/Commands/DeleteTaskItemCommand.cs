using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.TaskItems.Commands
{
    public record DeleteTaskItemCommand(string Id) : IRequest;
}
