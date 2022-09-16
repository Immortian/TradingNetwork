using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Models;

namespace TradingNetwork.API.Commands.CURDCommands.SalesPointCommands.CreateSalesPointCommand
{
    public class CreateSalesPointCommand
    {
        public string Name { get; set; }
        //public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
