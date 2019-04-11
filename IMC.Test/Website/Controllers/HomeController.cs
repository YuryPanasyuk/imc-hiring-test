using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUsModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cities(string province)
        {
            CitiesModel model = new CitiesModel();

            model.Cities = Classes.ImcProxy.GetCities(province);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}