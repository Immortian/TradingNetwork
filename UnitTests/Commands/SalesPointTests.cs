using CRUD.API.Handlers.CURDHandlers.SalesPointHandlers;
using Microsoft.EntityFrameworkCore;
using Shared.Commands.SalesPointCommands;
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
    public class SalesPointTests : TestCommandBase
    {
        [Fact]
        public async Task CreateSalesPointCommandHandlerTests()
        {
            var handler = new CreateSalesPointCommandHandler(Context);

            await handler.Create(
                new CreateSalesPointCommand
                {
                    Name = "SalesPoint 2"
                });

            Assert.NotNull(await Context.SalesPoints.SingleOrDefaultAsync(x => x.Name == "SalesPoint 2"));
        }

        [Fact]
        public async Task UpdateSalesPointCommandHandlerTests()
        {
            var handler = new UpdateSalesPointCommandHandler(Context);

            await handler.Update(
                new UpdateSalesPointCommand
                {
                    Id = 1,
                    Name = "1"
                });

            Assert.NotNull(await Context.SalesPoints.SingleOrDefaultAsync(x => x.Name == "1"));
        }
    }
}
