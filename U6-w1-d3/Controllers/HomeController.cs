using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U6_w1_d3.Models;

namespace U6_w1_d3.Controllers
{
    public class HomeController : Controller
    {
        public List<Scarpa> scarpa

        {
            get
            {
                List<Scarpa> scarpe = Scarpe.getScarpe();
                return scarpe;
            }
        }

        public ActionResult Index()
        {
            return View(scarpa);
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Scarpa dip)
        {
            Scarpe.addscarpa(dip);
            return RedirectToAction("Index");
        }

        public ActionResult admin(List<bool> check)
        {
            return View();
        }
    }
}