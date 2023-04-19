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
    public class OrderRepository : IOrderRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var records = await _context.Orders.ToListAsync();
            return _mapper.Map<List<OrderModel>>(records); //Auto Map the record
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            var park = await _context.Orders.FindAsync(orderId);
            return _mapper.Map<OrderModel>(park);
        }

        public async Task<long> AddOrderAsync(OrderModel orderModel)
        {
            var order = new Order()
            {
                ReservationNo = orderModel.ReservationNo,
                GuestId = orderModel.GuestId,
                CameraId = orderModel.CameraId,
                CameraNo = orderModel.CameraNo,
                ArrivalDate = orderModel.ArrivalDate,
                DepartureDate = orderModel.DepartureDate,
                Notes = orderModel.Notes,
                Status = orderModel.Status
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.OrderId;
        }
        public async Task UpdateOrderAsync(int orderId, OrderModel orderModel)
        {
            var order = new Order()
            {
                OrderId = orderId,
                ReservationNo = orderModel.ReservationNo,
                GuestId = orderModel.GuestId,
                CameraId = orderModel.CameraId,
                CameraNo = orderModel.CameraNo,
                ArrivalDate = orderModel.ArrivalDate,
                DepartureDate = orderModel.DepartureDate,
                Notes = orderModel.Notes,
                Status = orderModel.Status
            };

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = new Order()
            {
                OrderId = orderId
            };

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
