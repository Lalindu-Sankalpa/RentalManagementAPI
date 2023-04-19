
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Data
{
    public class Camera
    {
        [Key]
        public long id { get; set; }
        public string CameraNo { get; set; }
        public double Price { get; set; }
        public string CameraStatus { get; set; }
        public long CameraTypeId { get; set; }
        public bool IsActive { get; set; }

    }
}