using Shared.Commands.SaleDataCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.SaleDataHandlers
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
            if (_context.SaleDatas.Where(x => x.SaleId == request.SaleId
                                         && x.ProductId == request.ProductId).Any())
            {
                var current = _context.SaleDatas
                    .Where(x => x.SaleId == request.SaleId
                        && x.ProductId == request.ProductId)
                    .FirstOrDefault();

                current.ProductQuantity = request.ProductQuantity;
                current.ProductIdAmount = _context.Products
                    .Where(x => x.Id == request.ProductId)
                    .FirstOrDefault().Price * request.ProductQuantity;

                _context.Update(current);
                await _context.SaveChangesAsync();

                var sale = _context.Sales
                .Where(x => x.Id == request.SaleId)
                .FirstOrDefault();

                sale.TotalAmount = _context.SaleDatas
                    .Where(x => x.SaleId == request.SaleId)
                    .Sum(x => x.ProductIdAmount);

                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
