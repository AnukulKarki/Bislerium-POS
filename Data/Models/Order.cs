using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.Icons;

namespace Bislerium.Data.Models
{
    public class Order
    {
        public Guid OrderID { get; set; } = Guid.NewGuid();
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public String EmployeeRole { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        //public int Month { get; set; } = DateTime.Now.Month;
        public List<OrderItem> OrderItems { get; set; }
        public Double OrderTotalAmount { get; set; }

    }
}
