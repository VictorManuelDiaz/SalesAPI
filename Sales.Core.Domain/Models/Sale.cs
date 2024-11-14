using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sales.Core.Domain.Models
{
    public class Sale
    {
        public Guid sale_id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public DateTime sale_date { get; set; }
        public Guid user_id { get; set; }
        public Guid commerce_id { get; set; }
        public Guid state_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        [ForeignKey("commerce_id")]
        public Commerce Commerce { get; set; }
        [ForeignKey("state_id")]
        public State State { get; set; }
    }
}
