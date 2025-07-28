using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<Comment>> GetByTaskIdAsync(string taskId, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task AddAsync(Comment comment, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}
