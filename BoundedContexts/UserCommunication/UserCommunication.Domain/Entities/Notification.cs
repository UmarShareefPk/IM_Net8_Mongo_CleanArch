using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommunication.Domain.Entities
{
    public class Notification
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; } // e.g., TaskAssigned, MessageReceived
        public string ReferenceId { get; set; } // e.g., TaskId or MessageId
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
