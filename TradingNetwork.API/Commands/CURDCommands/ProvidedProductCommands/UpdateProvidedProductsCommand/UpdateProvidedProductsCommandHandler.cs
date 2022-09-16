using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Commands.CURDCommands.ProvidedProductCommands.UpdateProvidedProductsCommand
{
    public class UpdateProvidedProductsCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateProvidedProductsCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Update(UpdateProvidedProductCommand request)
        {
            if (_context.ProvidedProducts.Where(x => x.SalesPointId == request.SalesPointId
                                                  && x.ProductId == request.ProductId).Any())
            {
                var current = _context.ProvidedProducts
                    .Where(x => x.SalesPointId == request.SalesPointId
                        && x.ProductId == request.ProductId)
                    .FirstOrDefault();

                current.ProductQuantity = request.ProductQuantity;

                _context.Update(current);
                await _context.SaveChangesAsync();
            }
        }
    }
}
