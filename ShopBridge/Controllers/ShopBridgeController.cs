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
            public ShopBridgeController(IShopBridge shopBridge)
            {
                _shopBridge = shopBridge;
            }
            [HttpGet]
            [Route("all")]
            public async Task<IActionResult> GetAllItems()
            {
                var result = await _shopBridge.GetAllItems().ConfigureAwait(false);
                return BuildResponse(result);
            }
          
            [HttpGet]
            [Route("item/{itemId}")]
            public async Task<IActionResult> GetItemById(string itemId)
            {
                var result = await _shopBridge.GetItemById(itemId).ConfigureAwait(false);
                return BuildResponse(result);
            }

            [HttpPost]
            [Route("addItem")]
            public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
            {
                var result = await _shopBridge.AddItem(request).ConfigureAwait(false);
                return BuildResponse(result);
            }

            [HttpPut]
            [Route("updateItem")]
            public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest request)
            {
                var result = await _shopBridge.UpdateItem(request).ConfigureAwait(false);
                return BuildResponse(result);
            }

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
