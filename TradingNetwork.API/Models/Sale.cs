using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingNetwork.API.Models
{
    public class Sale
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        //public Guid SalesPointId { get; set; }
        public int SalesPointId { get; set; }
        //public Guid BuyerId { get; set; }
        public int BuyerId { get; set; }
        public List<SaleData> SalesData { get; set; }
        public double TotalAmount { get; set; }
    }
}
