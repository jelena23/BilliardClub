using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilliardClub.Models;
using BilliardClub.ViewModels;

namespace BilliardClub.Controllers
{
    public class BilliardTableController : Controller
    {
        private ApplicationDbContext _context;

        public BilliardTableController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: BilliardTable

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {
            var billiardTables = _context.BilliardTables.ToList();

            return View(billiardTables);
        }
    }
}