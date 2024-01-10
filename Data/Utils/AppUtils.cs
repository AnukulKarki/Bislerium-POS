using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Utils
{
    internal class AppUtils
    {

        public static string GetDesktopDirectoryPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }


        public static string GetCofeeListFilePath()
        {
            return Path.Combine(GetDesktopDirectoryPath(), "coffeeList.json");
        }

        public static string GetCustomerPath()
        {
            return Path.Combine(GetDesktopDirectoryPath(), "customer.json");
        }
        //getting the JSON Path for Adins
        public static string GetAddInItemListPath()
        {
            return Path.Combine(GetDesktopDirectoryPath(), "Addins.json");
        }
        public static string GetOrderListPath()
        {
            return Path.Combine(GetDesktopDirectoryPath(), "orders.json");
        }
        public static string GetOrderItemListPath()
        {
            return Path.Combine(GetDesktopDirectoryPath(), "orderItem.json");
        }


    }
}
