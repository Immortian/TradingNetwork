using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Commands.CURDCommands.SalesPointCommands.UpdateSalesPointCommand
{
    public class UpdateSalesPointCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateSalesPointCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateSalesPointCommand request)
        {
            if (_context.SalesPoints.Where(x => x.Id == request.Id).Any())
            {
                var current = _context.SalesPoints.Where(x => x.Id == request.Id).FirstOrDefault();
                current.Name = request.Name;
                _context.Update(current);
                await _context.SaveChangesAsync();
            }
        }
    }
}
