using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Models
{
    public class Customer
    {
        public Guid CustomerID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }   
        public int OrderCount { get; set; } = 0;
        public bool member { get; set; } = false;
    }
}
