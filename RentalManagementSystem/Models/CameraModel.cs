using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Models
{
    public class CameraModel
    {
        public long? id { get; set; }
        public string CameraNo { get; set; }
        public double Price { get; set; }
        public string CameraStatus { get; set; }
        public long CameraTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
