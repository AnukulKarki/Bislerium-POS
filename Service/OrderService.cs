using Bislerium.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bislerium.Data.Models;

namespace Bislerium.Service
{
    public class OrderService
    {
        public List<Order> GetOrdersFromJsonFile()
        {
            string orderListFilePath = AppUtils.GetOrderListPath();

            if (!File.Exists(orderListFilePath))
            {
                return new List<Order>();
            }

            var json = File.ReadAllText(orderListFilePath);

            return JsonSerializer.Deserialize<List<Order>>(json);
        }

        public void PlaceOrder(Order order)
        {
            List<Order> orders = GetOrdersFromJsonFile();
            orders.Add(order);

            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string orderListFilePath = AppUtils.GetOrderListPath();

            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }

            var json = JsonSerializer.Serialize(orders);

            File.WriteAllText(orderListFilePath, json);
        }
    }
}
