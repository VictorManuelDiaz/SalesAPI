using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Core.Domain.Models;

namespace Sales.Adapters.SQLDataAccess.Entities
{
    public class ECommerce : IEntityTypeConfiguration<Commerce>
    {
        public void Configure(EntityTypeBuilder<Commerce> builder)
        {
            builder.ToTable("tb_commerce");

            builder.HasKey(c => c.commerce_id);

            builder.HasOne(c => c.State);
        }
    }
}
