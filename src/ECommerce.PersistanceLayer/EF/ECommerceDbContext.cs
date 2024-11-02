using ECommerce.DomainLayer.Aggregates.Cargo;
using ECommerce.DomainLayer.Aggregates.Order;
using ECommerce.DomainLayer.Aggregates.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.PersistanceLayer.EF
{
    public class ECommerceDbContext : DbContext
    {
        private readonly IMediator mediator;

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options, IMediator mediator) : base (options)
        {
            this.mediator = mediator;
        }

        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<CargoRequest> CargoRequests { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.TotalAmount).Property(x => x.Amount).HasColumnName("Budget_Amount");
            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.TotalAmount).Property(x => x.Currency).HasColumnName("Budget_Currency");

            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.OrderStatus).Property(x => x.Text).HasColumnName("Status_Text");
            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.OrderStatus).Property(x => x.Value).HasColumnName("Status_Value");

            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.PaymentStatus).Property(x => x.Text).HasColumnName("Payment_Text");
            modelBuilder.Entity<OrderRequest>().OwnsOne(x => x.PaymentStatus).Property(x => x.Value).HasColumnName("Payment_Value");


            modelBuilder.Entity<ProductRequest>().OwnsOne(x => x.ProductCost).Property(x => x.Amount).HasColumnName("Cost_Amount");
            modelBuilder.Entity<ProductRequest>().OwnsOne(x => x.ProductCost).Property(x => x.Currency).HasColumnName("Cost_Currency");


            modelBuilder.Entity<ProductRequest>().OwnsOne(x => x.Status).Property(x => x.Text).HasColumnName("Status_Text");
            modelBuilder.Entity<ProductRequest>().OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status_Value");


            modelBuilder.Entity<CargoRequest>().OwnsOne(x => x.Status).Property(x => x.Text).HasColumnName("Status_Text");
            modelBuilder.Entity<CargoRequest>().OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status_Value");


            base.OnModelCreating(modelBuilder);
        }
    }
}
