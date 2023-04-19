using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class CameraType
    {
        [Key]
        public long id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
