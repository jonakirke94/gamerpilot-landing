using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamerPilotLanding.Data;
using Microsoft.AspNetCore.Mvc;
using GamerPilotLanding.Models;

namespace GamerPilotLanding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("feedback-panel")]
        public IActionResult Panel()
        {
            return View();
        }

        [HttpGet("om-os")]
        public IActionResult About()
        {
            return View();
        }


        [HttpGet("forældre")]
        public IActionResult Parents()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(string comment, string returnUrl)
        {
            if (string.IsNullOrEmpty(comment))
            {
                TempData["Error"] = "Tekstfeltet kan ikke være tomt!";
                return RedirectToAction(returnUrl);
            }

            var fb = new Feedback()
            {
                Comment = comment,
                Created = DateTime.Now
            };

            try
            {
                _context.Feedback.Add(fb);
                _context.SaveChanges();
                TempData["Success"] = "Tak for din feedback!";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Hov noget gik galt - Kontakt os gerne";
            }

            return RedirectToAction(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PanelRequest(string email, string returnUrl)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "Emailen kan ikke være tom";
                return RedirectToAction(returnUrl);
            }

            if (_context.PanelRequests.Any(x => x.Email == email))
            {
                TempData["Success"] = "Det ser ud til, at du allerede er skrevet op!";
                return RedirectToAction(returnUrl);
            }

            var user = new PanelUser()
            {
                Email = email,
                Created = DateTime.Now
            };

            try
            {
                _context.PanelRequests.Add(user);
                _context.SaveChanges();
                TempData["Success"] = "Tak! Vi kontakter dig hurtigst muligt";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Hov noget gik galt - Kontakt os gerne";
            }

            return RedirectToAction(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(string email, string returnUrl)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "Emailen kan ikke være tom";
                return RedirectToAction(returnUrl);
            }

            if (_context.Subscriptions.Any(x => x.Email == email))
            {
                TempData["Success"] = "Det ser ud til, at du allerede er skrevet op!";
                return RedirectToAction(returnUrl);
            }

            var user = new User()
            {
                Email = email,
                Created = DateTime.Now
            };

            try
            {
                _context.Subscriptions.Add(user);
                _context.SaveChanges();
                TempData["Success"] = "Du blev successfuldt skrevet op!";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Hov noget gik galt - Kontakt os gerne";
            }

            return RedirectToAction(returnUrl);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
