using ShopBridge.Model;

namespace ShopBridge.Core
{
    public interface IShopBridge
    {
        Task<GetItemsResponse> GetAllItems();

        Task<GetItemByIdResponse> GetItemById(string itemId);

        Task<AddItemResponse> AddItem(AddItemRequest request);

        Task<UpdateItemResponse> UpdateItem(UpdateItemRequest request);

        Task<RemoveItemResponse> RemoveItem(string itemId);
    }
}
