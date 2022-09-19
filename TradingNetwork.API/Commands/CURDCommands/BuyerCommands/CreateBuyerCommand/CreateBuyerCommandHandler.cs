using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.BuyerCommands.CreateBuyerCommand
{
    public class CreateBuyerCommandHandler
    {
        private TradingNetworkContext _context;

        public CreateBuyerCommandHandler(TradingNetworkContext context)
        {
            _context = context;
        }
        public async Task Create(CreateBuyerCommand request)
        {
            var buyer = new Buyer
            {
                Name = request.Name
            };
            await _context.Buyers.AddAsync(buyer);
            await _context.SaveChangesAsync();
        }
    }
}
