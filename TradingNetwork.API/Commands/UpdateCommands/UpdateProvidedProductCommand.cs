using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.UpdateCommands
{
    public class UpdateProvidedProductCommand
    {
        public int ProductId { get; set; }
        public int SalesPointId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
