using CRUD.API.Handlers.CURDHandlers.SaleHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.SaleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Commands
{
    public class SaleTests : TestCommandBase
    {
        [Fact]
        public async Task CreateSaleCommandHandlerTests()
        {
            var handler = new CreateSaleCommandHandler(Context);
            var date = DateTime.Now;

            await handler.Create(
                new CreateSaleCommand
                {
                    BuyerId = 1,
                    SalesPointId = 1,
                    DateTime = date
                });

            Assert.NotNull(await Context.Sales.SingleOrDefaultAsync(x => x.BuyerId == 1 && x.SalesPointId == 1 && x.DateTime == date));
        }

        [Fact]
        public async Task UpdateSaleCommandHandlerTests()
        {
            var handler = new UpdateSaleCommandHandler(Context);

            await handler.Update(
                new UpdateSaleCommand
                {
                    Id = 1,
                    TotalAmount = 3998,
                    DateTime = DateTime.Now
                });

            Assert.NotNull(await Context.Sales.SingleOrDefaultAsync(x => x.Id == 1 && x.TotalAmount == 3998));
        }
    }
}
