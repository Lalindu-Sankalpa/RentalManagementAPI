﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class User
    {
        [Key]

        public long id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
