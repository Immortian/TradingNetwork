using CRUD.API.Handlers.CURDHandlers.ProductHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.ProductCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Commands
{
    public class ProductTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandlerTests()
        {
            var handler = new CreateProductCommandHandler(Context);

            await handler.Create(
                new CreateProductCommand
                {
                    Name = "Product 4",
                    Price = 120
                });

            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(x => x.Name == "Product 4" && x.Price == 120));
        }

        [Fact]
        public async Task UpdateProductCommandHandlerTests()
        {
            var handler = new UpdateProductCommandHandler(Context);

            await handler.Update(
                new Product
                {
                    Id = 1,
                    Name = "1",
                    Price = 499
                });

            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(x => x.Name == "1" && x.Price == 499));
        }
    }
}
