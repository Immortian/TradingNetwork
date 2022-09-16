using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.ProductCommands.UpdateProductCommand
{
    public class UpdateProductComandHandler
    {
        private TradingNetworkContext _context;
        public UpdateProductComandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task Update(Product request)
        {
            if (_context.Products.Where(x => x.Id == request.Id).Any())
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
