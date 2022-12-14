using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.SaleIdsHandlers
{
    public class UpdateSalesIdsCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateSalesIdsCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        //Useless
        public async Task Update()
        {
            foreach (var sale in _context.Sales)
            {
                var current = _context.Buyers
                    .Where(x => x.Id == sale.BuyerId)
                    .FirstOrDefault();

                if (!current.SalesIds.Contains(sale))
                    current.SalesIds.Add(sale);

                _context.Update(current);
            }
            await _context.SaveChangesAsync();
        }
    }
}
