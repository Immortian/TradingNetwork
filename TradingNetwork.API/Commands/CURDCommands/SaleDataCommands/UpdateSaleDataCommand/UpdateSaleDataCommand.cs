using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.UpdateSaleDataCommand
{
    public class UpdateSaleDataCommand
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
