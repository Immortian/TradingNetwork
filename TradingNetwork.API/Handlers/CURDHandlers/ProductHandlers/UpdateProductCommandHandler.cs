using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private TradingNetworkContext _context;
        public UpdateProductCommandHandler(TradingNetworkContext context)
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
