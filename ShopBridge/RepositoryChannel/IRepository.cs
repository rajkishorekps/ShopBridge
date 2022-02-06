using ShopBridge.Entity;
using ShopBridge.Model;

namespace ShopBridge.RepositoryChannel
{
    public interface IRepository
    {
        Task<List<Item>> GetAllItems();

        Task<Item> GetItemById(string itemId);

        Task<int> AddItem(Item request);

        Task<bool> UpdateItem(Item request);

        Task<bool> RemoveItem(string itemId);
    }
}
