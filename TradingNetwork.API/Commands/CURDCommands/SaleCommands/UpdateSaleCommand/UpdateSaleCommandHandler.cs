using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Commands.CURDCommands.SaleCommands.UpdateSaleCommand
{
    public class UpdateSaleCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateSaleCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateSaleCommand request)
        {
            if (_context.Sales.Where(x => x.Id == request.Id).Any())
            {
                var current = _context.Sales.Where(x => x.Id == request.Id).FirstOrDefault();

                current.SalesPointId = request.SalesPointId;
                current.BuyerId = request.BuyerId;
                current.DateTime = request.DateTime;
                current.TotalAmount = request.TotalAmount;

                _context.Update(current);
                await _context.SaveChangesAsync();
            }
        }
    }
}
