using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Sales.Core.Domain.Models;

using Sales.Adapters.SQLDataAccess.Entities;

using Sales.Adapters.SQLDataAccess.Utils;

namespace Sales.Adapters.SQLDataAccess.Contexts
{
    public class SalesDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Commerce> Commerces { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUser());
            builder.ApplyConfiguration(new EState());
            builder.ApplyConfiguration(new ESale());
            builder.ApplyConfiguration(new ESaleDetail());
            builder.ApplyConfiguration(new ECommerce());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(GlobalSetting.SqlConnectionString);
        }
    }
}


