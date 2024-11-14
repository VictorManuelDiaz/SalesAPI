using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Core.Domain.Models
{
    public class Commerce
    {
        public Guid commerce_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string ruc { get; set; }
        public Guid state_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("state_id")]
        public State State { get; set; }
        public List<User> Users { get; set; }
    }
}
