using Shared.Common.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Repositories
{
    public interface IAttachmentRepository
    {
        Task<Attachment?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<Attachment>> GetByTargetAsync(string targetType, string targetId, CancellationToken cancellationToken = default);
        Task AddAsync(Attachment attachment, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}
