using CRUD.API.Handlers.CURDHandlers.SaleDataHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.SaleDataCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Commands
{
    public class SaleDataTests : TestCommandBase
    {
        [Fact]
        public async Task CreateSaleDataCommandHandlerTests()
        {
            var handler = new CreateSaleDataCommandHandler(Context);
            var date = DateTime.Now;

            await handler.Create(
                new CreateSaleDataCommand
                {
                    SaleId = 1,
                    ProductId = 3,
                    ProductQuantity = 1
                });

            Assert.NotNull(await Context.SaleDatas.SingleOrDefaultAsync(x => x.SaleId == 1 && x.ProductId == 3 && x.ProductQuantity == 1));
        }

        [Fact]
        public async Task UpdateSalesDataCommandHandlerTests()
        {
            var handler = new UpdateSaleDataCommandHandler(Context);

            await handler.Update(
                new UpdateSaleDataCommand
                {
                    SaleId = 1,
                    ProductId = 1,
                    ProductQuantity = 4
                });

            Assert.NotNull(await Context.SaleDatas.SingleOrDefaultAsync(x => x.SaleId == 1 && x.ProductId == 1 && x.ProductQuantity == 4));
        }
    }
}
