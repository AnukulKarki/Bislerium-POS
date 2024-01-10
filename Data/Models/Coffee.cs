using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Models
{
    public class Coffee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CoffeeType { get; set; }
        public double Price { get; set; }

    }
}
