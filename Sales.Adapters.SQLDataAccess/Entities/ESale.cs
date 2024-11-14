using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Core.Domain.Models;

namespace Sales.Adapters.SQLDataAccess.Entities
{
    public class ESale : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("tb_sale");

            builder.HasKey(s => s.sale_id);

            builder.HasOne(s => s.User);

            builder.HasOne(s => s.Commerce);

            builder.HasOne(s => s.State);

            builder
                .HasMany(s => s.SaleDetails)
                .WithOne(sd => sd.Sale);
        }
    }
}
