using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilliardClub.Models;

namespace BilliardClub.ViewModels
{
    public class RandomBilliardTableViewModel
    {
        public BilliardTable BilliardTable { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}