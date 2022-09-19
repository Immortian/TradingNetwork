using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Commands.CURDCommands.BuyerCommands.UpdateBuyerCommand
{
    public class UpdateBuyerCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateBuyerCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateBuyerCommand request)
        {
            if (_context.Buyers.Where(x => x.Id == request.Id).Any())
            {
                var current = _context.Buyers.Where(x => x.Id == request.Id).FirstOrDefault();
                current.Name = request.Name;
                _context.Update(current);
                await _context.SaveChangesAsync();
            }
        }
    }
}
