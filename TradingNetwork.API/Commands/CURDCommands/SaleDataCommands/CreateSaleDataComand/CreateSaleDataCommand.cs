using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.CreateSaleDataCommand
{
    public class CreateSaleDataCommand
    {
        public int ProductId { get; set; }
        public int SalesId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
