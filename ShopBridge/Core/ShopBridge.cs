using ShopBridge.Entity;
using ShopBridge.Model;
using ShopBridge.RepositoryChannel;
using System.Globalization;

namespace ShopBridge.Core
{
    public class ShopBridge : IShopBridge
    {
        private readonly IRepository _repository;
        public ShopBridge(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetItemsResponse> GetAllItems()
        {
            try
            {
                var items = await _repository.GetAllItems();
                var itemsModel = new List<Item>();
                foreach (var item in items)
                {
                    itemsModel.Add(new Item()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Description = item.Description
                    });
                }

                return new GetItemsResponse()
                {
                    Items = itemsModel
                };
            }
            catch (Exception ex)
            {
                return new GetItemsResponse()
                {
                    ErrorMessage = ex.Message
                };
            }

        }

        public async Task<GetItemByIdResponse> GetItemById(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
                {
                    throw new Exception("Item id is not valid !");
                }
                var item = await _repository.GetItemById(itemId);

                if (item == null)
                {
                    return new GetItemByIdResponse()
                    {
                        ErrorMessage = "The item with specified id could not be found!"
                    };
                }
                return new GetItemByIdResponse()
                {
                    Item = new Item()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Description = item.Description
                    }
                };
            }
            catch (Exception ex)
            {
                return new GetItemByIdResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<AddItemResponse> AddItem(AddItemRequest request)
        {
            try
            {
                Validate(request.Item);
                var itemToBeAdded = new Item()
                {
                    Name = request.Item.Name,
                    Description = request.Item.Description,
                    Price = request.Item.Price
                };
                var addedItemId = await _repository.AddItem(itemToBeAdded);
                return new AddItemResponse()
                {
                    AddedItemId = addedItemId
                };
            }
            catch (Exception ex)
            {
                return new AddItemResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<UpdateItemResponse> UpdateItem(UpdateItemRequest request)
        {
            try
            {
                Validate(request.Item);
                var itemToBeUpdated = new Item()
                {
                    Id = Convert.ToInt32(request.Item.Id),
                    Name = request.Item.Name,
                    Description = request.Item.Description,
                    Price = Convert.ToDecimal(request.Item.Price)
                };
                var result = await _repository.UpdateItem(itemToBeUpdated);
                return result ? new UpdateItemResponse() :
                    new UpdateItemResponse()
                    {
                        ErrorMessage = "The item with the specified id could not be updated!"
                    };
            }
            catch (Exception ex)
            {
                return new UpdateItemResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        private static void Validate(Item item)
        {
            if (item == null ||
                string.IsNullOrEmpty(item.Name) ||
                !item.Price.HasValue ||
                string.IsNullOrEmpty(item.Description))
            {
                throw new Exception("Missing params in AddItemRequest !");
            }

            if (!item.Price.HasValue)
            {
                throw new Exception("Item price is not valid !");
            }
        }

        public async Task<RemoveItemResponse> RemoveItem(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
                {
                    throw new Exception("Item id is not valid !");
                }

                var result = await _repository.RemoveItem(itemId);
                return result ? new RemoveItemResponse() :
                new RemoveItemResponse()
                {
                    ErrorMessage = "The item with the specified id could not be removed!"
                };
            }
            catch (Exception ex)
            {
                return new RemoveItemResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
