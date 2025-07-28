using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Enums
{
    public enum TaskItemStatus
    {
        [Description("New")]
        New,
        [Description("InProgress")]
        InProgress,
        [Description("Late")]
        Late,
        [Description("Closed")]
        Closed
    }
}
