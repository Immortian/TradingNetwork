using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.UpdateCommands
{
    public class UpdateSalesPointCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
