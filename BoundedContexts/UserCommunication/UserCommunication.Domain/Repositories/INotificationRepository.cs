using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCommunication.Domain.Entities;

namespace UserCommunication.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task AddAsync(Notification notification, CancellationToken cancellationToken = default);
        Task MarkAsReadAsync(string notificationId, CancellationToken cancellationToken = default);
        Task DeleteAsync(string notificationId, CancellationToken cancellationToken = default);
    }
}
