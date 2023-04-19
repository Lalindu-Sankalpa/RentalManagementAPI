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
    public class UserRepository : IUserRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public UserRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var records = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserModel>>(records); //Auto Map the record
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<long> AddUserAsync(UserModel userModel)
        {
            var user = new User()
            {
                email = userModel.email,
                password = userModel.password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.id;
        }
        public async Task UpdateUserAsync(int userId, UserModel userModel)
        {
            var user = new User()
            {
                id = userId,
                email = userModel.email,
                password = userModel.password
            };

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = new User()
            {
                id = userId
            };

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
