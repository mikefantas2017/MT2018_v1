using MT2018_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace MT2018_v1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MonWindow()
        {
            return View();
        }

        [HttpGet]
        public JsonResult BuscaModelo(string q, string limit)
        {
            var structure1 = new Structure() { Id = 1, Nombre = "Str0218 DFGD"};
            var structure2 = new Structure() { Id = 2, Nombre = "Str7897 A890S" };
            var structure3 = new Structure() { Id = 3, Nombre = "Atr4897 BDcs48" };
            var structureList = new List<Structure>() { structure1, structure2, structure3 };
            if (q == null)
            {
                q = " ";
            }
            var res = (from r in structureList
                                           where r.Nombre.Contains(q)
                                           select new
                                           {
                                               id = r.Id,
                                               text = r.Nombre
                                           }).Take(Convert.ToInt32(10)).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}