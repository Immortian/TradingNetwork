using Shared.Commands.SalesPointCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.SalesPointHandlers
{
    public class CreateSalesPointCommandHandler
    {
        private TradingNetworkContext _context;
        public CreateSalesPointCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Create(CreateSalesPointCommand request)
        {
            var salesPoint = new SalesPoint
            {
                Name = request.Name
            };
            await _context.SalesPoints.AddAsync(salesPoint);
            await _context.SaveChangesAsync();
        }
    }
}
