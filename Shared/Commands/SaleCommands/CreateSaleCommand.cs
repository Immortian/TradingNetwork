using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commands.SaleCommands
{
    public class CreateSaleCommand
    {
        public DateTime DateTime { get; set; }
        public int SalesPointId { get; set; }
        public int? BuyerId { get; set; }
    }
}
