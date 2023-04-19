using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RentalManagementSystem.Models
{
    public class UserModel : IdentityUser
    {
        public long? id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
