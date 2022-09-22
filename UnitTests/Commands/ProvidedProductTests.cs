using CRUD.API.Handlers.CURDHandlers.ProvidedProductHandlers;
using CRUD.API.Handlers.CURDHandlers.ProvidedProductHanlders;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.ProvidedProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Commands
{
    public class ProvidedProductTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandlerTests()
        {
            var handler = new CreateProvidedProductsCommandHandler(Context);

            await handler.Create(
                new CreateProvidedProductCommand
                {
                    ProductId = 3,
                    SalesPointId = 1,
                    ProductQuantity = 1
                });

            Assert.NotNull(await Context.ProvidedProducts.SingleOrDefaultAsync(x => x.ProductId == 3 && x.SalesPointId == 1 && x.ProductQuantity == 1));
        }

        [Fact]
        public async Task UpdateProvidedProductCommandHandlerTests()
        {
            var handler = new UpdateProvidedProductsCommandHandler(Context);

            await handler.Update(
                new UpdateProvidedProductCommand
                {
                    ProductId = 1,
                    SalesPointId = 1,
                    ProductQuantity = 2
                });

            Assert.NotNull(await Context.ProvidedProducts.SingleOrDefaultAsync(x => x.ProductId == 1 && x.SalesPointId == 1 && x.ProductQuantity == 2));
        }
    }
}
