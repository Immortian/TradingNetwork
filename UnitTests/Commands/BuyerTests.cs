using CRUD.API.Handlers.CURDHandlers.BuyerHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.BuyerCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Commands
{
    public class BuyerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBuyerCommandHandlerTests()
        {
            var handler = new CreateBuyerCommandHandler(Context);

            await handler.Create(
                new CreateBuyerCommand
                {
                    Name = "Buyer 2"
                });

            Assert.NotNull(await Context.Buyers.SingleOrDefaultAsync(x => x.Name == "Buyer 2"));
        }

        [Fact]
        public async Task UpdateBuyerCommandHandlerTests()
        {
            var handler = new UpdateBuyerCommandHandler(Context);

            await handler.Update(
                new UpdateBuyerCommand
                {
                    Id = 1,
                    Name = "1"
                });

            Assert.NotNull(await Context.Buyers.SingleOrDefaultAsync(x => x.Name == "1"));
        }
    }
}
