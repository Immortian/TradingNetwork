using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Data
{
    public class TradingNetworkContextFactory
    {
        public static TradingNetworkContext Create()
        {
            var options = new DbContextOptionsBuilder<TradingNetworkContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TradingNetworkContext(options);

            context.Database.EnsureCreated();

            context.Products.AddRange(RandomProducts());
            context.SalesPoints.AddRange(RandomSalesPoints());
            context.Sales.AddRange(RandomSales(context.Products.ToList()));
            context.Buyers.AddRange(RandomBuyers(context.Sales.ToList()));

            context.SaveChanges();
            return context;
        }
        private static Random r = new Random();
        private static List<Product> RandomProducts()
        {
            var products = new List<Product>();
            for(int productId = 1; productId < 11; productId++)
            {
                products.Add(
                    new Product
                    {
                        Id = productId,
                        Name = $"Product {productId}",
                        Price = r.Next(50, 10000)
                    });
            }
            return products;
        }
        private static List<SalesPoint> RandomSalesPoints()
        {
            var salesPoints = new List<SalesPoint>();

            for(int salesPointId = 1; salesPointId < 11; salesPointId++)
            {
                var provided = new List<ProvidedProduct>();

                for(int productId = 1; productId < 11; productId++)
                {
                    provided.Add(new ProvidedProduct
                    {
                        ProductId = productId,
                        ProductQuantity = r.Next(0, 10)
                    });
                }

                salesPoints.Add(
                    new SalesPoint
                    {
                        Id = salesPointId,
                        Name = $"Sales point {salesPointId}",
                        ProvidedProducts = provided
                    });
            }

            return salesPoints;
        }
        private static List<Sale> RandomSales(List<Product> products)
        {
            var sales = new List<Sale>();
            TimeSpan timeSpan = new DateTime(2010, 1, 1) - DateTime.Now;
            
            for (int saleId = 1; saleId < 11; saleId++)
            {
                var salesData = new List<SaleData>();
                var buyedProductsIds = new List<int>();
                for (int item = 0; item < 3; item++)
                {
                    var productId = r.Next(1, 10);

                    while(buyedProductsIds.Contains(productId))
                        productId = r.Next(1, 10);
                    
                    buyedProductsIds.Add(productId);
                    var quantity = r.Next(1, 5);

                    salesData.Add(
                        new SaleData
                        {
                            ProductId = productId,
                            ProductQuantity = quantity,
                            ProductIdAmount = products
                                .Where(x => x.Id == productId)
                                .Select(x => x.Price)
                                .FirstOrDefault() * quantity
                        });
                }

                TimeSpan newSpan = new TimeSpan(0, r.Next(0, (int)timeSpan.TotalMinutes), 0);
                sales.Add(
                    new Sale
                    {
                        Id = saleId,
                        BuyerId = r.Next(1, 10),
                        DateTime = new DateTime(2010, 1, 1) + newSpan,
                        SalesPointId = r.Next(1, 10),
                        SalesData = salesData
                    });
            }
            return sales;
        }
        private static List<Buyer> RandomBuyers(List<Sale> sales)
        {
            var buyers = new List<Buyer>();
            for (int buyerId = 1; buyerId < 11; buyerId++)
            {
                buyers.Add(
                    new Buyer
                    {
                        Id = buyerId,
                        Name = $"Name {buyerId}",
                        SalesIds = sales
                        .Where(x => x.BuyerId == buyerId)
                        .Select(x => x.Id)
                        .ToList()
                    });
            }
            return buyers;
        }
    }
}
