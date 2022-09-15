using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Models
{
    public class SalesPoint
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
