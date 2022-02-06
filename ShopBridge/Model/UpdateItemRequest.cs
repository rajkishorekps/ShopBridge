using ShopBridge.Entity;

namespace ShopBridge.Model
{
    public class UpdateItemRequest : BaseResponse
    {
        public Item Item { get; set; }
    }
}
