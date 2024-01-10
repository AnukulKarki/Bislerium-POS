using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Models
{
    //Model for items to hold in cart
    public class OrderItem
    {
        public Guid OrderItemID { get; set; } = Guid.NewGuid();
        //public Guid OrderID { get; set; }
        public Guid ItemID { get; set; } // Coffee and Addins list
        public string Name { get; set; } //name of the item
        public string ItemType { get; set; } //item type: Coffee and add ins
        public int Quantity { get; set; } //quantity
        public double Price { get; set; } //each price
        public double TotalPrice { get; set; } //total price

        public DateTime OrderItemDateTime { get; set; } = DateTime.Now;
    }
}
