using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilliardClub.Models;

namespace BilliardClub.ViewModels
{
    public class BilliardTableViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
        public BilliardTable BilliardTable { get; set; }
    }
}