﻿// <auto-generated />
using System;
using ECommerce.PersistanceLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.PersistanceLayer.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Cargo.CargoRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderRequestId");

                    b.HasIndex("ProductRequestId");

                    b.ToTable("CargoRequests");
                });

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Order.OrderRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderRequests");
                });

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Product.ProductRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductRequests");
                });

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Cargo.CargoRequest", b =>
                {
                    b.HasOne("ECommerce.DomainLayer.Aggregates.Order.OrderRequest", "OrderRequest")
                        .WithMany()
                        .HasForeignKey("OrderRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.DomainLayer.Aggregates.Product.ProductRequest", "ProductRequest")
                        .WithMany()
                        .HasForeignKey("ProductRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Cargo.CargoRequestStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("CargoRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("CargoRequestId");

                            b1.ToTable("CargoRequests");

                            b1.WithOwner()
                                .HasForeignKey("CargoRequestId");
                        });

                    b.Navigation("OrderRequest");

                    b.Navigation("ProductRequest");

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Order.OrderRequest", b =>
                {
                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Shared.Money", "TotalAmount", b1 =>
                        {
                            b1.Property<Guid>("OrderRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Budget_Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Budget_Currency");

                            b1.HasKey("OrderRequestId");

                            b1.ToTable("OrderRequests");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestId");
                        });

                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Order.OrderRequestStatus", "OrderStatus", b1 =>
                        {
                            b1.Property<Guid>("OrderRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("OrderRequestId");

                            b1.ToTable("OrderRequests");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestId");
                        });

                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Order.PaymentRequestStatus", "PaymentStatus", b1 =>
                        {
                            b1.Property<Guid>("OrderRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Payment_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Payment_Value");

                            b1.HasKey("OrderRequestId");

                            b1.ToTable("OrderRequests");

                            b1.WithOwner()
                                .HasForeignKey("OrderRequestId");
                        });

                    b.Navigation("OrderStatus")
                        .IsRequired();

                    b.Navigation("PaymentStatus")
                        .IsRequired();

                    b.Navigation("TotalAmount")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.DomainLayer.Aggregates.Product.ProductRequest", b =>
                {
                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Shared.Money", "ProductCost", b1 =>
                        {
                            b1.Property<Guid>("ProductRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Cost_Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Cost_Currency");

                            b1.HasKey("ProductRequestId");

                            b1.ToTable("ProductRequests");

                            b1.WithOwner()
                                .HasForeignKey("ProductRequestId");
                        });

                    b.OwnsOne("ECommerce.DomainLayer.Aggregates.Product.ProductRequestStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("ProductRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("ProductRequestId");

                            b1.ToTable("ProductRequests");

                            b1.WithOwner()
                                .HasForeignKey("ProductRequestId");
                        });

                    b.Navigation("ProductCost")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}