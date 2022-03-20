using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BilliardClub.Hubs;
using BilliardClub.Models;
using BilliardClub.ViewModels;
using Itenso.TimePeriod;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;


namespace BilliardClub.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        public ReservationController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Mvc.Authorize(Roles = "Employee")]
        public ActionResult GetAllReservationRecords()
        {
            var reservations = _context.Reservations.ToList();
            return PartialView("_GetAllReservationRecords", reservations);
        }

        public ActionResult New()
        {
            var billiardTables = _context.BilliardTables.ToList();
            var viewModel = new ReservationFormViewModel
            {
                Reservation = new Reservation(),
                BilliardTables = billiardTables
            };

            return View("ReservationForm", viewModel);
        }

        //Finding Gaps
        public IList<Reservation> GetGaps(IEnumerable<Reservation> periods)
        {
            TimeGapCalculator<TimeRange> gapCalculator = new TimeGapCalculator<TimeRange>();

            var tomorrow = DateTime.Today.AddDays(1);
            var workingHoursStart = new TimeSpan(8, 00, 00);
            var startPeriod = tomorrow + workingHoursStart;
            var startPeriod1 = tomorrow + workingHoursStart;
            var endPeriod = startPeriod.AddDays(7).AddHours(14);
            var endPeriod1 = startPeriod.AddDays(7).AddHours(14);

            System.Diagnostics.Debug.WriteLine(startPeriod);

            TimePeriodCollection calcPeriods = new TimePeriodCollection();

            calcPeriods.Add(new TimeRange(startPeriod, startPeriod1));
            calcPeriods.Add(new TimeRange(endPeriod, endPeriod1));

            foreach (Reservation period in periods)
            {
                if (period.StartTime > DateTime.Now)
                {
                    calcPeriods.Add(new TimeRange(period.StartTime, period.EndTime));
                }
                
            }
            List<Reservation> gaps = new List<Reservation>();
            if (calcPeriods.Count == 0)
            {
                return gaps;
            }

            ITimePeriodCollection calcCaps = gapCalculator.GetGaps(calcPeriods);
            foreach (TimeRange calcCap in calcCaps)
            {
                gaps.Add(new Reservation { StartTime = calcCap.Start, EndTime = calcCap.End });
            }

            return gaps;
        }

        //Finding gaps in filtered reservations
        public ActionResult FreeSlotsForTable(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var tableReservations = _context.Reservations.Where(r => r.BilliardTableId == id).ToList();
            var gaps = GetGaps(tableReservations);

            return View("_FreeSlotsForTable",gaps);
        }

        //Check if reservation exists
        public bool ReservationOk(int id, DateTime start, DateTime end)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var tableReservations = _context.Reservations.Where(r => r.BilliardTableId == id).ToList();

            foreach (var tr in tableReservations)
            {
                if (start == tr.StartTime || end == tr.StartTime)
                    return false;
            }

            return true;
        }

        //Creating new reservation
        [HttpPost]
        public ActionResult Save(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ReservationFormViewModel
                {
                    Reservation = reservation,
                    BilliardTables = _context.BilliardTables.ToList()
                };
                return View("ReservationForm", viewModel);
            }

            if (reservation.ReservationId == 0)
            {
                reservation.ResDateTime = DateTime.Now;
                reservation.ClientId = User.Identity.GetUserId();

                if (ReservationOk(reservation.BilliardTableId, reservation.StartTime, reservation.EndTime) == false)
                    return HttpNotFound();

                _context.Reservations.Add(reservation);
            }

            _context.SaveChanges();

            ReservationHub.ShowReservation();

            return RedirectToAction("Index", "Home");
        }
    }
}