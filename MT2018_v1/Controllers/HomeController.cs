using MT2018_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Configuration;

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
            var p1 = "Alo";
            bool connSucc = false;
            ViewBag.Persona = p1;
            MySqlConnection db = new MySqlConnection();
            // Cadena de conexión, para prueba de conexión con MySQL.
            db.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLdbprueba1"].ConnectionString;
            try
            {
                db.Open();
                connSucc = true;
                ViewBag.ConnMess = "Conexión establecida.";
                MySqlCommand q = db.CreateCommand();
                q.CommandType = System.Data.CommandType.Text;
                q.CommandText = "select nombre from personas where id = 2;";
                MySqlDataReader dr = q.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        p1 = dr.GetString(0);
                        ViewBag.Persona = p1;
                    }
                }
                dr.Close();
            }
            catch (Exception e)
            {
                ViewBag.ConnMess = "Fallo en la conexión.";
            }
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