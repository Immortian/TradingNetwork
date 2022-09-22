using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace UnitTests.Common
{
    public class TradingNetworkContextFactory
    {
        public static TradingNetworkContext Create()
        {
            var option = new DbContextOptionsBuilder<TradingNetworkContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TradingNetworkContext(option);
            context.Database.EnsureCreated();

            context.Buyers.AddRange(
                new Buyer
                {
                    Id = 1,
                    Name = "Buyer 1"
                });
            context.Products.AddRange(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 500
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 999
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Price = 600
                });
            context.SalesPoints.AddRange(
                new SalesPoint
                {
                    Id = 1,
                    Name = "SalesPoint 1"
                });
            context.ProvidedProducts.AddRange(
                new ProvidedProduct
                {
                    ProductId = 1,
                    SalesPointId = 1,
                    ProductQuantity = 5
                },
                new ProvidedProduct
                {
                    ProductId = 2,
                    SalesPointId = 1,
                    ProductQuantity = 3
                });
            context.Sales.AddRange(
                new Sale
                {
                    Id = 1,
                    BuyerId = 1,
                    SalesPointId = 1,
                    DateTime = DateTime.Now - new TimeSpan(0, 1, 0),
                    TotalAmount = 2998
                });
            context.SaleDatas.AddRange(
                new SaleData
                {
                    ProductId = 1,
                    SaleId = 1,
                    ProductQuantity = 2,
                    ProductIdAmount = 1000
                },
                new SaleData
                {
                    ProductId = 2,
                    SaleId = 1,
                    ProductQuantity = 2,
                    ProductIdAmount = 1998
                });
            context.SaveChanges();
            return context;
        }
        public static void Destroy(TradingNetworkContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
