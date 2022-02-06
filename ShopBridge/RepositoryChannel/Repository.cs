using ShopBridge.Entity;
using ShopBridge.Model;
using System.Data.Entity;

namespace ShopBridge.RepositoryChannel
{
    public class Repository : IRepository
    {
        public async Task<List<Item>> GetAllItems()
        {
            using (var dataContext = new ShopBridgeContext())
            {
                return await dataContext.Items.ToListAsync();
            }
        }

        public async Task<Item> GetItemById(string itemId)
        {
            using (var inventoryDataContext = new ShopBridgeContext())
            {
                return await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(itemId));
            }
        }

        public async Task<int> AddItem(Item item)
        {
            using (var inventoryDataContext = new ShopBridgeContext())
            {
                await inventoryDataContext.Items.AddAsync(item);
                await inventoryDataContext.SaveChangesAsync();
                return item.Id;
            }
        }

        public async Task<bool> UpdateItem(Item item)
        {
            using (var inventoryDataContext = new ShopBridgeContext())
            {
                var itemToBeUpdated = await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (itemToBeUpdated != null)
                {
                    itemToBeUpdated.Price = item.Price;
                    itemToBeUpdated.Name = item.Name;
                    itemToBeUpdated.Description = item.Description;
                    await inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> RemoveItem(string itemId)
        {
            using (var inventoryDataContext = new ShopBridgeContext())
            {
                var itemToBeDeleted = await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(itemId));
                if (itemToBeDeleted != null)
                {
                    inventoryDataContext.Items.Remove(itemToBeDeleted);
                    await inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
    }
}
