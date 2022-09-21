using Shared.Commands.SaleCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.SaleHandlers
{
    public class CreateSaleCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateSaleCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task<Sale> Create(CreateSaleCommand request)
        {
            var sale = new Sale
            {
                SalesPointId = request.SalesPointId,
                BuyerId = request.BuyerId,
                DateTime = request.DateTime
            };
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
