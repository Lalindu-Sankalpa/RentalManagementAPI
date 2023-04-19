using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddOrder([FromBody] OrderModel orderModel)
        {
            var id = await _orderRepository.AddOrderAsync(orderModel);
            return CreatedAtAction(nameof(GetOrderById), new { id = id, controller = "Order" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderModel orderModel, [FromRoute] int id)
        {
            await _orderRepository.UpdateOrderAsync(id, orderModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return Ok();
        }

    }
}
