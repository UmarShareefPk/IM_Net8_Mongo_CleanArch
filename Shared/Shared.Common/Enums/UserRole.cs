using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Enums
{
    public enum UserRole
    {
   
        [Description("System")]
        SuperAdmin,

        [Description("Admin")]
        Admin,

        [Description("Moderator")]
        Moderator,        
        
        [Description("Viewer")]
        Viewer,

        [Description("Guest")]
        Guest
    }
}
