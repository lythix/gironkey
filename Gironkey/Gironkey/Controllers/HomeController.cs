using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gironkey.Models;
using Gironkey.Services;

namespace Gironkey.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ZoneQuery query)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(query.Address);
                if (!string.IsNullOrEmpty(query.Address))
                {
                    return RedirectToAction("Search", query);

                    // return RedirectToAction("Search", "Home", query);
                }
            }
            ViewBag.Message = "(Giraffes by name, monkeys by nature).";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //
        // POST: /Home/Search

        //[HttpPost]
        public ActionResult Search(ZoneQuery query)
        {
            if (ModelState.IsValid)
            {
                var service = new GironkeyService();
                // ViewBag.Result = service.GetDataForAddress(query.Address);
                query.LatLong = "115.90114501745099,-31.915819563332345";
                query.LatLong = "115.802821,-31.940334";
                ViewBag.Result = service.CallLandgate(query.LatLong); // .CallLandgateGetJson();

                Console.WriteLine(query.Address);
            }

            return View(query);
        }


    }
}
