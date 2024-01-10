using Bislerium.Data.Utils;
using System.Text.Json;
using Bislerium.Data.Models;

namespace Bislerium.Service
{
    public class AddInsServices
    {
        private readonly List<AddInItem> _addInItemsList = new()
        {
            new() { Name = "Extra Sugar", Price = 10.0 },
            new() { Name = "Whipped Cream", Price = 15.0 },
            new() { Name = "Chocolate Syrup", Price = 12.0 },
            new() { Name = "Vanilla Extract", Price = 18.0 },
            new() { Name = "Caramel Drizzle", Price = 22.0 },
            new() { Name = "Hazelnut Flavor", Price = 20.0 },
            new() { Name = "Cinnamon Powder", Price = 17.0 },
            new() { Name = "Almond Milk", Price = 25.0 },
            new() { Name = "Whiskey Shot", Price = 30.0 },
            new() { Name = "Special Syrup Blend", Price = 28.0 }
        };


        public void SaveAddInJson(List<AddInItem> addInItemList)
        {
            string appDataDirPath = AppUtils.GetDesktopDirectoryPath();
            string addInItemsListListFilePath = AppUtils.GetAddInItemListPath();

            if (!Directory.Exists(appDataDirPath))
            {
                Directory.CreateDirectory(appDataDirPath);
            }

            var json = JsonSerializer.Serialize(addInItemList);

            File.WriteAllText(addInItemsListListFilePath, json);
        }
        public List<AddInItem> GetAddInsItems()
        {
            string addInsItemsListListFilePath = AppUtils.GetAddInItemListPath();

            if (!File.Exists(addInsItemsListListFilePath))
            {
                return new List<AddInItem>();
            }

            var json = File.ReadAllText(addInsItemsListListFilePath);

            return JsonSerializer.Deserialize<List<AddInItem>>(json);
        }


        public void SeedAddInItemsList()
        {
            List<AddInItem> addInsList = GetAddInsItems();

            if (addInsList.Count == 0)
            {
                SaveAddInJson(_addInItemsList);
            }
        }

        public AddInItem GetAddInItemDetailsByID(String addInItemID)
        {
            List<AddInItem> AddIns = GetAddInsItems();
            AddInItem addInItem = AddIns.FirstOrDefault(addIn => addIn.Id.ToString() == addInItemID);
            return addInItem;
        }


        public void UpdateAddInItemDetails(AddInItem addInItem)
        {
            List<AddInItem> addInItemsList = GetAddInsItems();

            AddInItem addInItemToUpdate = addInItemsList.FirstOrDefault(_addInItem => _addInItem.Id.ToString().Equals(addInItem.Id.ToString()));

            if (addInItemToUpdate == null)
            {
                throw new Exception("Add-In item not found");
            }

            addInItemToUpdate.Name = addInItem.Name;
            addInItemToUpdate.Price = addInItem.Price;

            SaveAddInJson(addInItemsList);
        }
    }
}
