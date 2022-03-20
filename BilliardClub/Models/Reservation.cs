using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BilliardClub.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ResDateTime { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public ApplicationUser Client { get; set; }
        public string ClientId { get; set; }
        public BilliardTable BilliardTable { get; set; }
        [Required]
        public int BilliardTableId { get; set; }
    }
}