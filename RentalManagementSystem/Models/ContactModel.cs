using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Models
{
    public class ContactModel
    {
        public long? id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string DateOfBirth { get; set; }
        public string IdNo { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
