using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Core.Domain.Enums
{
    public enum StateType
    {
        [Description("Active")]
        Active = 1,

        [Description("Inactive")]
        Inactive = 2,

        [Description("Pending")]
        Pending = 3,

        [Description("Completed")]
        Completed = 4,

        [Description("Canceled")]
        Canceled = 5
    }
}
