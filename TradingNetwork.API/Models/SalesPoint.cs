using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Models
{
    public class SalesPoint
    {
        public SalesPoint()
        {
            ProvidedProducts = new HashSet<ProvidedProduct>();
        }

        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
