using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetAllItemsAsync();
        Task<ItemModel> GetItemByIdAsync(int itemId);
        Task<long> AddItemAsync(ItemModel itemModel);
        Task UpdateItemAsync(int itemId, ItemModel itemModel);
        Task DeleteItemAsync(int itemId);
    }
}
