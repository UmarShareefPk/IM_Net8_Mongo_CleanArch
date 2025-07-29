using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Enums
{
    public enum TaskItemStatus
    {
        [EnumMember(Value = "new")]
        New,

        [EnumMember(Value = "in_progress")]
        InProgress,

        [EnumMember(Value = "late")]
        Late,

        [EnumMember(Value = "closed")]
        Closed
    }
}
