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
    public class LenseRepository : ILenseRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public LenseRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LenseModel>> GetAllLensesAsync()
        {
            var records = await _context.Lenses.ToListAsync();
            return _mapper.Map<List<LenseModel>>(records); //Auto Map the record
        }

        public async Task<LenseModel> GetLenseByIdAsync(int lenseId)
        {
            var park = await _context.Lenses.FindAsync(lenseId);
            return _mapper.Map<LenseModel>(park);
        }

        public async Task<long> AddLenseAsync(LenseModel lenseModel)
        {
            var lense = new Lense()
            {
                Name = lenseModel.Name,
                CategoryId = lenseModel.CategoryId,
                Quantity = lenseModel.Quantity,
                Date = lenseModel.Date,
                Code = lenseModel.Code,
                Status = lenseModel.Status,
                Notes = lenseModel.Notes
            };

            _context.Lenses.Add(lense);
            await _context.SaveChangesAsync();

            return lense.LenseId;
        }
        public async Task UpdateLenseAsync(int lenseId, LenseModel lenseModel)
        {
            var lense = new Lense()
            {
                LenseId = lenseId,
                Name = lenseModel.Name,
                CategoryId = lenseModel.CategoryId,
                Quantity = lenseModel.Quantity,
                Date = lenseModel.Date,
                Code = lenseModel.Code,
                Status = lenseModel.Status,
                Notes = lenseModel.Notes
            };

            _context.Lenses.Update(lense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLenseAsync(int lenseId)
        {
            var lense = new Lense()
            {
                LenseId = lenseId
            };

            _context.Lenses.Remove(lense);

            await _context.SaveChangesAsync();
        }
    }
}
