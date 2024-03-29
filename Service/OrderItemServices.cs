﻿using Bislerium.Data.Utils;
using System.Text.Json;
using Bislerium.Data.Models;

namespace Bislerium.Service
{
    public class OrderItemServices
    {
        //adding the order item in the list of orderItem
        public void AddItemInOrderList(List<OrderItem> _orderItems, Guid itemID, String ItemType, Double ItemPrice, string name)
        {
            OrderItem orderItem = _orderItems.FirstOrDefault(x => x.ItemID == itemID && x.ItemType == ItemType);

            if (orderItem != null)
            {
                //increase the quantity value if already exist
                orderItem.Quantity++;
                //update the price of the value if added again
                orderItem.TotalPrice = orderItem.Quantity * ItemPrice;
                return; 
            }
            else
            {

                orderItem = new()
                {
                    Name = name,
                    ItemID = itemID,
                    ItemType = ItemType,
                    Quantity = 1,
                    Price = ItemPrice,
                    TotalPrice = ItemPrice
                };
                //add the item in the list
                _orderItems.Add(orderItem);
            }
            


        }

        public void DeleteItemInOrderItemsList(List<OrderItem> _orderItems, Guid orderItemID)
        {
            OrderItem orderItem = _orderItems.FirstOrDefault(x => x.OrderItemID == orderItemID);

            if (orderItem != null)
            {
                _orderItems.Remove(orderItem);
            }
        }

        public void QuantityOfItemList(List<OrderItem> _orderItems, Guid orderItemID, String action)
        {
            OrderItem orderItem = _orderItems.FirstOrDefault(x => x.OrderItemID == orderItemID);

            if (orderItem != null)
            {
                if (action == "add")
                {
                    orderItem.Quantity++;
                    orderItem.TotalPrice = orderItem.Quantity * orderItem.Price;
                }
                //decrease the quantity by 1
                else if (action == "sub" && orderItem.Quantity > 1)
                {
                    orderItem.Quantity--;
                    orderItem.TotalPrice = orderItem.Quantity * orderItem.Price;
                }
                //remove the item if quantity is 0
                else if(action == "sub" && orderItem.Quantity == 1)
                {
                    _orderItems.Remove(orderItem);
                }
            }
        }
        public List<OrderItem> GetOrderListFromJsonFile()
        {
            string orderListFilePath = AppUtils.GetOrderItemListPath();

            if (!File.Exists(orderListFilePath))
            {
                return new List<OrderItem>();
            }

            var json = File.ReadAllText(orderListFilePath);

            return JsonSerializer.Deserialize<List<OrderItem>>(json);
        }

        public void SaveOrderList(OrderItem order)
        {
            List<OrderItem> orders = GetOrderListFromJsonFile();
            orders.Add(order);

            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string orderListFilePath = AppUtils.GetOrderItemListPath();

            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }

            var json = JsonSerializer.Serialize(orders);

            File.WriteAllText(orderListFilePath, json);
        }
    }
}
