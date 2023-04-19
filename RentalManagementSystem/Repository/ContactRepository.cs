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
    public class ContactRepository: IContactRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> GetAllContactsAsync()
        {
            var records = await _context.Contacts.ToListAsync();
            return _mapper.Map<List<ContactModel>>(records); //Auto Map the record
        }

        public async Task<ContactModel> GetContactByIdAsync(int contactId)
        {
            var park = await _context.Contacts.FindAsync(contactId);
            return _mapper.Map<ContactModel>(park);
        }

        public async Task<long> AddContactAsync(ContactModel contactModel)
        {
            var contact = new Contact()
            {
                Name = contactModel.Name,
                DateOfBirth = contactModel.DateOfBirth,
                Email = contactModel.Email,
                PhoneNo = contactModel.PhoneNo,
                IdNo = contactModel.IdNo,
                IsActive = contactModel.IsActive
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact.id;
        }
        public async Task UpdateContactAsync(int contactId, ContactModel contactModel)
        {
            var contact = new Contact()
            {
                id = contactId,
                Name = contactModel.Name,
                DateOfBirth = contactModel.DateOfBirth,
                Email = contactModel.Email,
                PhoneNo = contactModel.PhoneNo,
                IdNo = contactModel.IdNo,
                IsActive = contactModel.IsActive
            };

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = new Contact()
            {
                id = contactId
            };

            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();
        }
    }
}