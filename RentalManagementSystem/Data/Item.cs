using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class Item
    {
        [Key]
        public long ItemsId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string AccNo { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}
