using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Seeding random data
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(TradingNetworkContext context)
        {
            context.Database.EnsureCreated();

            context.Products.AddRange(RandomProducts());
            context.SaveChanges();
            context.ProvidedProducts.AddRange(RandomProvidedProducts());
            context.SaveChanges();
            context.SalesPoints.AddRange(RandomSalesPoints(context.ProvidedProducts.ToList()));
            context.SaleDatas.AddRange(RandomSaleData(context.Products.ToList()));
            context.SaveChanges();
            context.Sales.AddRange(RandomSales(context.SaleDatas.ToList()));
            context.SaveChanges();
            context.Buyers.AddRange(RandomBuyers(context.Sales.ToList()));
            context.SaveChanges();
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
        private static List<ProvidedProduct> RandomProvidedProducts()
        {
            var provided = new List<ProvidedProduct>();
            for (int salesPointId = 1; salesPointId < 11; salesPointId++)
            {
                for (int productId = 1; productId < 11; productId++)
                {
                    provided.Add(new ProvidedProduct
                    {
                        SalesPointId = salesPointId,
                        ProductId = productId,
                        ProductQuantity = r.Next(0, 10)
                    });
                }
            }
            return provided;
        }
        private static List<SalesPoint> RandomSalesPoints(List<ProvidedProduct> providedProducts)
        {
            var salesPoints = new List<SalesPoint>();

            for(int salesPointId = 1; salesPointId < 11; salesPointId++)
            {
                
                salesPoints.Add(
                    new SalesPoint
                    {
                        Id = salesPointId,
                        Name = $"Sales point {salesPointId}",
                        ProvidedProducts = providedProducts.Where(x => x.SalesPointId == salesPointId).ToList()
                    });
            }

            return salesPoints;
        }
        private static List<SaleData> RandomSaleData(List<Product> products)
        {
            var salesData = new List<SaleData>();
            for (int saleId = 1; saleId < 11; saleId++)
            {
                var buyedProductsIds = new List<int>();
                for (int item = 0; item < 3; item++)
                {
                    var productId = r.Next(1, 10);

                    while (buyedProductsIds.Contains(productId))
                        productId = r.Next(1, 10);

                    buyedProductsIds.Add(productId);
                    var quantity = r.Next(1, 5);

                    salesData.Add(
                        new SaleData
                        {
                            SaleId = saleId,
                            ProductId = productId,
                            ProductQuantity = quantity,
                            ProductIdAmount = products
                                .Where(x => x.Id == productId)
                                .Select(x => x.Price)
                                .FirstOrDefault() * quantity
                        });
                }
            }
            return salesData;
        }
        private static List<Sale> RandomSales(List<SaleData> saleData)
        {
            var sales = new List<Sale>();
            TimeSpan timeSpan = DateTime.Now - new DateTime(2010, 1, 1);
            
            for (int saleId = 1; saleId < 11; saleId++)
            {
                TimeSpan newSpan = new TimeSpan(0, r.Next(0, (int)timeSpan.TotalMinutes), 0);
                sales.Add(
                    new Sale
                    {
                        Id = saleId,
                        BuyerId = r.Next(1, 10),
                        DateTime = new DateTime(2010, 1, 1) + newSpan,
                        SalesPointId = r.Next(1, 10),
                        SalesData = saleData.Where(x => x.SaleId == saleId).ToList(),
                        TotalAmount = saleData.Where(x => x.SaleId == saleId).Sum(x => x.ProductIdAmount)
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
                            .ToList()
                    });
            }
            return buyers;
        }
    }
}
