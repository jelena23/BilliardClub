using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilliardClub.Models;

namespace BilliardClub.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
        public Client Client { get; set; }
    }
}