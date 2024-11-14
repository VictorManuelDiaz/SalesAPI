﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sales.Adapters.SQLDataAccess.Contexts;

#nullable disable

namespace Sales.Adapters.SQLDataAccess.Migrations
{
    [DbContext(typeof(SalesDB))]
    [Migration("20241114031932_CommerceUserUpdate")]
    partial class CommerceUserUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sales.Core.Domain.Models.Commerce", b =>
                {
                    b.Property<Guid>("commerce_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("ruc")
                        .HasColumnType("text");

                    b.Property<Guid>("state_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("commerce_id");

                    b.HasIndex("state_id");

                    b.HasIndex("user_id");

                    b.ToTable("tb_commerce", (string)null);
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.Sale", b =>
                {
                    b.Property<Guid>("sale_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("commerce_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<DateTime>("sale_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("state_id")
                        .HasColumnType("uuid");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("sale_id");

                    b.HasIndex("commerce_id");

                    b.HasIndex("state_id");

                    b.HasIndex("user_id");

                    b.ToTable("tb_sale", (string)null);
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.SaleDetail", b =>
                {
                    b.Property<Guid>("deatil_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<string>("product")
                        .HasColumnType("text");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("sale_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("deatil_id");

                    b.HasIndex("sale_id");

                    b.ToTable("tb_sale_detail", (string)null);
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.State", b =>
                {
                    b.Property<Guid>("state_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("name")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("state_id");

                    b.ToTable("tb_state", (string)null);
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.User", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.Property<Guid>("state_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("user_id");

                    b.HasIndex("state_id");

                    b.ToTable("tb_user", (string)null);
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.Commerce", b =>
                {
                    b.HasOne("Sales.Core.Domain.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Core.Domain.Models.State", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.Sale", b =>
                {
                    b.HasOne("Sales.Core.Domain.Models.Commerce", "Commerce")
                        .WithMany()
                        .HasForeignKey("commerce_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Core.Domain.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Core.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commerce");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.SaleDetail", b =>
                {
                    b.HasOne("Sales.Core.Domain.Models.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("sale_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Sales.Core.Domain.Models.User", b =>
                {
                    b.HasOne("Sales.Core.Domain.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
