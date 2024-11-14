using System;
using System.Collections.Generic;
using System.Text;
using Sales.Core.Domain.Enums;

namespace Sales.Core.Domain.Models
{
    public class State
    {
        public Guid state_id { get; set; }
        public StateType name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
