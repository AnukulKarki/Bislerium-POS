using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Models
{
    public class Report
    {
        public List<Order> Orders { get; set; }
        public string ReportType { get; set; }
        public string ReportDate { get; set; }
        public double TotalRevenue { get; set; } = 0;
        public List<OrderItem> CoffeeLists { get; set; }
        public List<OrderItem> AddInsLists { get; set; }

    }
}
