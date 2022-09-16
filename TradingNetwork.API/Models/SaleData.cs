using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Models
{
    public class SaleData
    {
        //public Guid ProductId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductIdAmount { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
