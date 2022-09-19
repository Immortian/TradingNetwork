using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.UpdateSaleDataCommand
{
    public class UpdateSaleDataCommandHandler
    {
        private TradingNetworkContext _context;

        public UpdateSaleDataCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task Update(UpdateSaleDataCommand request)
        {
            if (_context.SaleDatas.Where(x => x.SaleId == request.SalesId
                                         && x.ProductId == request.ProductId).Any())
            {
                var current = _context.SaleDatas
                    .Where(x => x.SaleId == request.SalesId
                        && x.ProductId == request.ProductId)
                    .FirstOrDefault();

                current.ProductQuantity = request.ProductQuantity;
                current.ProductIdAmount = _context.Products
                    .Where(x => x.Id == request.ProductId)
                    .FirstOrDefault().Price * request.ProductQuantity;

                _context.Update(current);
                await _context.SaveChangesAsync();
            }
        }
    }
}
