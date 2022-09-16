using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Models
{
    public class ProvidedProduct
    {
        //public Guid ProductId { get; set; }
        public int ProductId { get; set; }
        public int SalesPointId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesPoint SalesPoint { get; set; }
    }
}
