using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CURDCommands.BuyerCommands.UpdateBuyerCommand
{
    public class UpdateBuyerCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
