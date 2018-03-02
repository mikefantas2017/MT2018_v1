using MT2018_v1.Models;
using System;
using System.Linq;
using System.Web.Mvc;

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
            ConnectDB cdb = new ConnectDB();
            var structureList = cdb.ObtenerModelos();
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