using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sales.Core.Domain.Models
{
    public class SaleDetail
    {
        public Guid deatil_id { get; set; }
        public Guid sale_id { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("sale_id")]
        [JsonIgnore]
        public Sale Sale { get; set; }
    }
}
