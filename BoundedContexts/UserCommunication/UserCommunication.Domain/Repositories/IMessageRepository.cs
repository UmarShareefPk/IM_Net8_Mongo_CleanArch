using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunication.Domain.Entities;

namespace UserCommunication.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<Message>> GetConversationAsync(string userId1, string userId2, CancellationToken cancellationToken = default);
        Task AddAsync(Message message, CancellationToken cancellationToken = default);
        Task MarkAsReadAsync(string id, CancellationToken cancellationToken = default);
    }
}
