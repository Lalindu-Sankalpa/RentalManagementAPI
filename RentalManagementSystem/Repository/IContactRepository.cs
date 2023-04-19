using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAllContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int contactId);
        Task<long> AddContactAsync(ContactModel contactModel);
        Task UpdateContactAsync(int contactId, ContactModel contactModel);
        Task DeleteContactAsync(int contactId);
    }
}
