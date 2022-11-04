using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopping.Data;
using shopping.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult man()
        {
            var result = db.man.ToList();

            return View(result);
        }

        public IActionResult women()
        {
            var result = db.women.ToList();
            return View(result);
        }

        public IActionResult childeren()
        {
            var result = db.childeren.ToList();
            return View(result);
        }
        public IActionResult perfumes()
        {
            var result = db.Perfumes.ToList();
            return View(result);
        }

        public IActionResult shoeses()
        {
            var result = db.Shoeses.ToList();
            return View(result);
        }


        public IActionResult mobilephone()
        {
            var result = db.MobilePhone.ToList();
            return View(result);
        }

        public IActionResult electronics()
        {
            var result = db.Electronics.ToList();
            return View(result);
        }

        public IActionResult grocery()
        {
            var result = db.Grocery.ToList();
            return View(result);
        }
        public IActionResult feedback()
        {
            return View();
        }

        public IActionResult feedbacksave(Feedback model)
        {
            db.Feedback.Add(model);
            db.SaveChanges();
            return RedirectToActionPermanent("index");

        }


        public IActionResult manageaccount()
        {
            return View();
        }
        [HttpGet]
        public IActionResult addcart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addcartsave(order model)
        {

            db.order.Add(model);
            db.SaveChanges();
            return RedirectToActionPermanent("perfumes");

        }

        public IActionResult viewcart()
        {
            var result = db.order.ToList();
            return View(result);
        }
    }
}
