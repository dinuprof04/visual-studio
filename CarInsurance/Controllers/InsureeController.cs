using CarInsurance.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsureeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Insuree/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Insuree/Create
        [HttpPost]
        public IActionResult Create(Insuree insuree)
        {
            if (!ModelState.IsValid)
            {
                return View(insuree);
            }

            // Safety checks
            if (insuree.Age < 0) insuree.Age = 0;
            if (insuree.CarYear < 0) insuree.CarYear = 0;
            if (insuree.SpeedingTickets < 0) insuree.SpeedingTickets = 0;

            decimal quote = 50m; // base

            // Age rules
            if (insuree.Age <= 18) quote += 100m;
            else if (insuree.Age <= 25) quote += 50m;
            else quote += 25m;

            // Car year rules
            if (insuree.CarYear < 2000) quote += 25m;
            if (insuree.CarYear > 2015) quote += 25m;

            // Porsche rules
            if (!string.IsNullOrWhiteSpace(insuree.CarMake) &&
                insuree.CarMake.Trim().Equals("Porsche", StringComparison.OrdinalIgnoreCase))
            {
                quote += 25m;

                if (!string.IsNullOrWhiteSpace(insuree.CarModel) &&
                    insuree.CarModel.Trim().Equals("911 Carrera", StringComparison.OrdinalIgnoreCase))
                {
                    quote += 25m;
                }
            }

            // Speeding tickets
            quote += insuree.SpeedingTickets * 10m;

            // DUI adds 25%
            if (insuree.DUI) quote *= 1.25m;

            // Full coverage adds 50%
            if (insuree.FullCoverage) quote *= 1.50m;

            insuree.Quote = Math.Round(quote, 2);

            _context.Insurees.Add(insuree);
            _context.SaveChanges();

            return RedirectToAction("Admin");
        }

        // GET: /Insuree/Admin
        [HttpGet]
        public IActionResult Admin()
        {
            var insurees = _context.Insurees.ToList();
            return View(insurees);
        }
    }
}
