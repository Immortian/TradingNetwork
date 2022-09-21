using Shared.Commands.BuyerCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace CRUD.API.Handlers.CURDHandlers.BuyerHandlers
{
    public class CreateBuyerCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateBuyerCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task<Buyer> Create(CreateBuyerCommand request)
        {
            var buyer = new Buyer
            {
                Name = request.Name
            };
            await _context.Buyers.AddAsync(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }
    }
}
