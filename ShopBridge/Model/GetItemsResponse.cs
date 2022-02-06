

using ShopBridge.Entity;

namespace ShopBridge.Model
{
    public class GetItemsResponse: BaseResponse
    {
        public List<Item> Items { get; set; }
    }
}
