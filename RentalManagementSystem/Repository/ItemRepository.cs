using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace RentalManagementSystem.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public ItemRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItemModel>> GetAllItemsAsync()
        {
            var records = await _context.Items.ToListAsync();
            return _mapper.Map<List<ItemModel>>(records); //Auto Map the record
        }

        public async Task<ItemModel> GetItemByIdAsync(int itemId)
        {
            var park = await _context.Items.FindAsync(itemId);
            return _mapper.Map<ItemModel>(park);
        }

        public async Task<long> AddItemAsync(ItemModel itemModel)
        {
            var item = new Item()
            {
                Description = itemModel.Description,
                Name = itemModel.Name,
                AccNo = itemModel.AccNo,
                Price = itemModel.Price,
                Status = itemModel.Status
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item.ItemsId;
        }
        public async Task UpdateItemAsync(int itemId, ItemModel itemModel)
        {
            var item = new Item()
            {
                ItemsId = itemId,
                Description = itemModel.Description,
                Name = itemModel.Name,
                AccNo = itemModel.AccNo,
                Price = itemModel.Price,
                Status = itemModel.Status
            };

            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = new Item()
            {
                ItemsId = itemId
            };

            _context.Items.Remove(item);

            await _context.SaveChangesAsync();
        }
    }
}