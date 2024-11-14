using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Core.Domain.Models;

namespace Sales.Adapters.SQLDataAccess.Entities
{
    public class ESaleDetail : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("tb_sale_detail");

            builder.HasKey(c => c.deatil_id);

        }
    }
}
