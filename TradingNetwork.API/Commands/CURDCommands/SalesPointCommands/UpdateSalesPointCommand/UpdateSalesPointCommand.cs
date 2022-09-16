using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CURDCommands.SalesPointCommands.UpdateSalesPointCommand
{
    public class UpdateSalesPointCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
