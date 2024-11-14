using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sales.Core.Domain.Enums;

namespace Sales.Core.Domain.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public RoleType role { get; set; }
        public Guid state_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("state_id")]
        public State State { get; set; }
    }
}
