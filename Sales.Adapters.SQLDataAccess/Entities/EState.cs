using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Core.Domain.Models;

namespace Sales.Adapters.SQLDataAccess.Entities
{
    public class EState : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("tb_state");

            builder.HasKey(s => s.state_id);
        }
    }
}
