using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.ProductCommands.CreateProductCommand
{
    public class CreateProductCommandHandler
    {
        private TradingNetworkContext _context;
        public CreateProductCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(CreateProductCommand request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
