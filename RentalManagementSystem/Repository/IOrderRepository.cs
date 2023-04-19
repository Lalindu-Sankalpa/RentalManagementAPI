using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int orderId);
        Task<long> AddOrderAsync(OrderModel orderModel);
        Task UpdateOrderAsync(int orderId, OrderModel orderModel);
        Task DeleteOrderAsync(int orderId);
    }
}
