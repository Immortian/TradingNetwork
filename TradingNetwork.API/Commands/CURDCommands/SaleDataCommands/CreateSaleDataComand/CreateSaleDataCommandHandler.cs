using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.CreateSaleDataCommand
{
    public class CreateSaleDataCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateSaleDataCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }

        public async Task Create(CreateSaleDataCommand request)
        {
            var pId = request.ProductId;
            var saleData = new SaleData
            {
                ProductId = pId,
                SaleId = request.SalesId,
                ProductQuantity = request.ProductQuantity,
                ProductIdAmount = _context.Products
                    .Where(x => x.Id == pId)
                    .FirstOrDefault().Price * request.ProductQuantity
            };

            if (_context.SaleDatas.Contains(saleData))
                _context.SaleDatas.Remove(saleData);

            await _context.SaleDatas.AddAsync(saleData);
            await _context.SaveChangesAsync();
        }
    }
}
