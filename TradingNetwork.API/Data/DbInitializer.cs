using CRUD.API.Handlers.CURDHandlers.BuyerHandlers;
using CRUD.API.Handlers.CURDHandlers.ProductHandlers;
using CRUD.API.Handlers.CURDHandlers.ProvidedProductHandlers;
using CRUD.API.Handlers.CURDHandlers.SaleDataHandlers;
using CRUD.API.Handlers.CURDHandlers.SaleHandlers;
using CRUD.API.Handlers.CURDHandlers.SalesPointHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.BuyerCommands;
using Shared.Commands.ProductCommands;
using Shared.Commands.ProvidedProductCommands;
using Shared.Commands.SaleCommands;
using Shared.Commands.SaleDataCommands;
using Shared.Commands.SalesPointCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Data
{
    public class DbInitializer
    {
        private TradingNetworkContext _context;
        public DbInitializer(TradingNetworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seeding random data
        /// </summary>
        /// <param name="context"></param>
        public async Task Initialize()
        {
            _context.Database.EnsureCreated();

            await RandomBuyers();
            await RandomProducts(); 
            await RandomSalesPoints();
            await RandomProvidedProducts();
            await RandomSales();
            await RandomSaleData();
        }

        private static Random r = new Random();
        private async Task RandomProducts()
        {
            var handler = new CreateProductCommandHandler(_context);
            for(int productId = 1; productId < 11; productId++)
            {
                await handler.Create(
                    new CreateProductCommand
                    {
                        Name = $"Product {productId}",
                        Price = r.Next(50, 10000)
                    });
            }
        }
        private async Task RandomProvidedProducts()
        {
            var handler = new CreateProvidedProductsCommandHandler(_context);
            for (int salesPointId = 1; salesPointId < 11; salesPointId++)
            {
                for (int productId = 1; productId < 11; productId++)
                {
                    await handler.Create(
                        new CreateProvidedProductCommand
                        {
                            SalesPointId = salesPointId,
                            ProductId = productId,
                            ProductQuantity = r.Next(0, 10)
                        });
                }
            }
        }
        private async Task RandomSalesPoints()
        {
            var handler = new CreateSalesPointCommandHandler(_context);

            for(int salesPointId = 1; salesPointId < 11; salesPointId++)
            {
                await handler.Create(
                    new CreateSalesPointCommand
                    {
                        Name = $"Sales point {salesPointId}"
                    });
            }
        }
        private async Task RandomSaleData()
        {
            var handler = new CreateSaleDataCommandHandler(_context);
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

                    await handler.Create(
                        new CreateSaleDataCommand
                        {
                            SaleId = saleId,
                            ProductId = productId,
                            ProductQuantity = quantity
                        });
                }
            }
        }
        private async Task RandomSales()
        {
            var handler = new CreateSaleCommandHandler(_context);
            TimeSpan timeSpan = DateTime.Now - new DateTime(2010, 1, 1);
            
            for (int saleId = 1; saleId < 11; saleId++)
            {
                TimeSpan newSpan = new TimeSpan(0, r.Next(0, (int)timeSpan.TotalMinutes), 0);

                await handler.Create(
                    new CreateSaleCommand
                    {
                        BuyerId = r.Next(1, 10),
                        DateTime = new DateTime(2010, 1, 1) + newSpan,
                        SalesPointId = r.Next(1, 10)
                    });                
            }
        }
        private async Task RandomBuyers()
        {
            var handler = new CreateBuyerCommandHandler(_context);
            for (int buyerId = 1; buyerId < 11; buyerId++)
            {
                await handler.Create(
                    new CreateBuyerCommand
                    {
                        Name = $"Name {buyerId}"
                    });
            }
        }
    }
}
