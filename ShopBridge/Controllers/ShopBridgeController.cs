using Microsoft.AspNetCore.Mvc;
using ShopBridge.Core;
using ShopBridge.Model;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("api/ShopBridge")]
    public class ShopBridgeController : ControllerBase
    {
            private readonly IShopBridge _shopBridge;
            /// <summary>
            /// InventoryController constructor
            /// </summary>
            /// <param name="shopBridge"></param>
            public ShopBridgeController(IShopBridge shopBridge)
            {
                _shopBridge = shopBridge;
            }

            /// <summary>
            /// This API can be used to get the list of all the items available in the inventory
            /// </summary>
            /// <returns>GetItemsResponse having list of all the available items in the inventory</returns>
            [HttpGet]
            [Route("all")]
            public async Task<IActionResult> GetAllItems()
            {
                var result = await _shopBridge.GetAllItems().ConfigureAwait(false);
                return BuildResponse(result);
            }

            /// <summary>
            /// This API can be used to get a particular item details by item id
            /// </summary>
            /// <param name="itemId">Item id of the requested item</param>
            /// <returns>GetItemByIdResponse having the Item details of the requested item</returns>
            [HttpGet]
            [Route("item/{itemId}")]
            public async Task<IActionResult> GetItemById(string itemId)
            {
                var result = await _shopBridge.GetItemById(itemId).ConfigureAwait(false);
                return BuildResponse(result);
            }

            /// <summary>
            /// This API can be used to add an item to the inventory
            /// </summary>
            /// <param name="request">AddItemRequest having the item details to be added</param>
            /// <returns>AddItemResponse having the AddedItemId</returns>
            [HttpPost]
            [Route("addItem")]
            public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
            {
                var result = await _shopBridge.AddItem(request).ConfigureAwait(false);
                return BuildResponse(result);
            }

            /// <summary>
            /// This API can be used to update the item details of a specific item
            /// </summary>
            /// <param name="request">UpdateItemRequest having the item details to be updated</param>
            /// <returns>UpdateItemResponse</returns>
            [HttpPut]
            [Route("updateItem")]
            public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest request)
            {
                var result = await _shopBridge.UpdateItem(request).ConfigureAwait(false);
                return BuildResponse(result);
            }

            /// <summary>
            /// This API can be used to remove any item from the inventory
            /// </summary>
            /// <param name="itemId">Item id of the item to be removed</param>
            /// <returns>RemoveItemResponse</returns>
            [HttpDelete]
            [Route("removeItem")]
            public async Task<IActionResult> RemoveItem(string itemId)
            {
                var result = await _shopBridge.RemoveItem(itemId).ConfigureAwait(false);
                return BuildResponse(result);
            }

            private ActionResult BuildResponse(BaseResponse response)
            {
                return new JsonResult(response);
            }
        }
    }
