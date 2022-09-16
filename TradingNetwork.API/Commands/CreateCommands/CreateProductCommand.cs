using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Commands.CreateCommands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
