using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.ProvidedProductCommands.CreateProvidedProductCommand
{
    public class CreateProvidedProductCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateProvidedProductCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        
        public async Task Create(CreateProvidedProductCommand request)
        {
            var product = new ProvidedProduct
            {
                ProductId = request.ProductId,
                SalesPointId = request.SalesPointId,
                ProductQuantity = request.ProductQuantity
            };
            await _context.ProvidedProducts.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
