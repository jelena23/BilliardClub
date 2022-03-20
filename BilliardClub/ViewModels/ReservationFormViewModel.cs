using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilliardClub.Models;

namespace BilliardClub.ViewModels
{
    public class ReservationFormViewModel
    {
        public IEnumerable<BilliardTable> BilliardTables { get; set; }
        public Reservation Reservation { get; set; }

    }
}