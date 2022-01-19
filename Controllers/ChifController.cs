using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TownWebApp.Controllers
{
    public class ChifController : Controller
    {
        // GET: Chif
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PresentChif()
        {
            try
            {

                ViewBag.str = "Wellcome Chif";
               return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}