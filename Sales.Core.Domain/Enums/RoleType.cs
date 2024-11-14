using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Core.Domain.Enums
{
    public enum RoleType
    {
        [Description("Owner")]
        Owner = 1,

        [Description("Employee")]
        Employee = 2
    }
}
