using Shared.Commands.SaleDataCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Commands
{
    public class SaleCommand
    {
        public int SalesPointId { get; set; }
        public int? BuyerId { get; set; }

        public virtual ICollection<CreateSaleDataCommand> SalesData { get; set; }
    }
}
