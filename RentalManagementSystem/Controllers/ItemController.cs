using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddItem([FromBody] ItemModel itemModel)
        {
            var id = await _itemRepository.AddItemAsync(itemModel);
            return CreatedAtAction(nameof(GetItemById), new { id = id, controller = "Item" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem([FromBody] ItemModel itemModel, [FromRoute] int id)
        {
            await _itemRepository.UpdateItemAsync(id, itemModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            await _itemRepository.DeleteItemAsync(id);
            return Ok();
        }

    }
}
