using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class Staffplan
    {
        [Key]
        public long StaffplanId { get; set; }
        public long UserId { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Break { get; set; }
        public string Point { get; set; }
    }
}
