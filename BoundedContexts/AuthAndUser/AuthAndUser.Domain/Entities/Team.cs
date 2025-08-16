using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Entities
{
    public class Team
    {
        public string? Id { get; set; }
        public string TeamName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public string OwnerId { get; set; } = null!;
        public string LogoUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;
        public string LastUpdatedBy { get; set; } = null!;
    }

}
