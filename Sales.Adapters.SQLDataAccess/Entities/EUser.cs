using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Core.Domain.Models;

namespace Sales.Adapters.SQLDataAccess.Entities
{
    public class EUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");

            builder.HasKey(u => u.user_id);

            builder.HasOne(u => u.Commerce)
                .WithMany()
                   .HasForeignKey(u => u.commerce_id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.State);
        }
    }
}

