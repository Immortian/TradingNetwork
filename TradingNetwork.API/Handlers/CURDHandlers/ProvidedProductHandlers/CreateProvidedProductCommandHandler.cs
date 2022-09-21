using Shared.Commands.ProvidedProductCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.ProvidedProductHandlers
{
    public class CreateProvidedProductsCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateProvidedProductsCommandHandler(TradingNetworkContext context)
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
