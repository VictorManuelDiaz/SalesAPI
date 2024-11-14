using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sales.Core.Domain.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public Guid commerce_id { get; set; }
        public Guid state_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("commerce_id")]
        public Commerce Commerce { get; set; }
        [ForeignKey("state_id")]
        public State State { get; set; }
    }
}
