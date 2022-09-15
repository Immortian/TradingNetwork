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
    }
}
