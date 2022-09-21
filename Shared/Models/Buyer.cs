using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Buyer
    {
        public Buyer()
        {
            SalesIds = new HashSet<Sale>();
        }

        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Guid> SalesIds { get; set; }

        public virtual ICollection<Sale> SalesIds { get; set; }
    }
}
