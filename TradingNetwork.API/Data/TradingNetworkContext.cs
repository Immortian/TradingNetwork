using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Data
{
    public class TradingNetworkContext : DbContext
    {
        public TradingNetworkContext(DbContextOptions<TradingNetworkContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }
        public DbSet<SaleData> SaleDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SalesPoint>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sale>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProvidedProduct>()
                .HasKey(c => new { c.ProductId, c.SalesPointId });
            modelBuilder.Entity<SaleData>()
                .HasKey(c => new { c.ProductId, c.SaleId });
        }
    }
}
