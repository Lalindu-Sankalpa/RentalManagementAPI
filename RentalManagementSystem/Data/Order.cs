using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public string ReservationNo { get; set; }
        public long GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public long CameraId { get; set; }
        public string CameraNo { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
