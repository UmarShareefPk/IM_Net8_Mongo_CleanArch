using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Application.TaskItems.Commands.Handlers
{
    public class DeleteTaskItemHandler : IRequestHandler<DeleteTaskItemCommand>
    {
        private readonly ITaskItemRepository _repository;

        public DeleteTaskItemHandler(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
