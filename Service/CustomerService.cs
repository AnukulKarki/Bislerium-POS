using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bislerium.Data.Models;
using Bislerium.Data.Utils;

namespace Bislerium.Service
{
    public class CustomerService
    {
        public List<Customer> _customerDetails = new();
        public void SaveCustomerDetailsInJson(Customer newCustomer)
        {
            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string customerListFilePath = AppUtils.GetCustomerPath();

            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }
            List<Customer> oldCustomer = getCustomerListFromJson();
            oldCustomer.Add(newCustomer);

            var json = JsonSerializer.Serialize(oldCustomer);

            File.WriteAllText(customerListFilePath, json);
        }

        //return the list with the data of the customer
        public List<Customer> getCustomerListFromJson()
        {
            string customerListFilePath = AppUtils.GetCustomerPath();

            if (!File.Exists(customerListFilePath))
            {
                return new List<Customer>();
            }

            var json = File.ReadAllText(customerListFilePath);

            return JsonSerializer.Deserialize<List<Customer>>(json);
        }

        public Customer getCustomerFromPhone(string phone)
        {
            List<Customer> customerList = getCustomerListFromJson();
            Customer customer = customerList.FirstOrDefault(_customer=> _customer.Phone.ToString() == phone);
            return customer;
        }
        public void addCustomerInJson(string username, string phone, string address)
        {
            Customer customer = new()
            {
                Phone = phone,
                Address = address,
                Name = username,
            };
            SaveCustomerDetailsInJson(customer);
        }
        public void editCustomerOrderCount(string phone)
        {
            List<Customer> customerList = getCustomerListFromJson();
            Customer customer = customerList.FirstOrDefault(_customer => _customer.Phone.ToString() == phone);
            customer.OrderCount++;

            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string customerListFilePath = AppUtils.GetCustomerPath();
            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }
            var json = JsonSerializer.Serialize(customerList);

            File.WriteAllText(customerListFilePath, json);
        }
        public void resetOrderCount(string phone)
        {
            List<Customer> customerList = getCustomerListFromJson();
            Customer customer = customerList.FirstOrDefault(_customer => _customer.Phone.ToString() == phone);
            customer.OrderCount = 0;

            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string customerListFilePath = AppUtils.GetCustomerPath();
            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }
            var json = JsonSerializer.Serialize(customerList);

            File.WriteAllText(customerListFilePath, json);
        }

        public void isMemberUpdate(string phone, List<Order> orderList)
        {
            //query for getting Data Count
            int DataCount = orderList.Where(a => a.CustomerPhone == phone && a.OrderDateTime.Equals(DateTime.Now.AddMonths(-1))).GroupBy(a => a.OrderDateTime).Count();
            List<Customer> customerList = getCustomerListFromJson();
            Customer customer = customerList.FirstOrDefault(_customer => _customer.Phone.ToString().Equals(phone));
            if (DataCount >= 21)
            {
                customer.member = true;
            }
            else
            {
                customer.member = false;
            }
            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string customerListFilePath = AppUtils.GetCustomerPath();
            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }
            var json = JsonSerializer.Serialize(customerList);

            File.WriteAllText(customerListFilePath, json);
        }
    }
}
