using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CURDCommands.SaleCommands.UpdateSaleCommand
{
    public class UpdateSaleCommand
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int SalesPointId { get; set; }
        public int BuyerId { get; set; }
        public double TotalAmount { get; set; }
    }
}
