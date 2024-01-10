using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bislerium.Data.Models;

namespace Bislerium.Data.Models
{
    public class ReportPdf
    {
        public List<ProductSalesQuantity> CoffeeItem { get; set; }
        public List<ProductSalesQuantity> AddIns { get; set; }

    }
}
