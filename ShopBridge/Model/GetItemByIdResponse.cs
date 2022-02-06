using ShopBridge.Entity;

namespace ShopBridge.Model
{
    public class GetItemByIdResponse: BaseResponse
    {
        public Item Item { get; set; }
    }
}
