using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commands.SaleCommands
{
    public class UpdateSaleCommand
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalAmount { get; set; }
    }
}
