using AuthAndUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAndUser.Domain.Models
{
    public class UsersWithPage
    {
        public long Total_Users { get; set; }
        public List<User> Users { get; set; }
    }
}
