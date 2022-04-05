using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoMVC.Models;

namespace cursoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IngresarDatos(string usuario, string password){


            try
            {
                using (cursoMVCEntities obj = new cursoMVCEntities())
                {
                    var lst = from users in obj.users
                              join cstate in obj.cstate on users.IdState equals cstate.Id
                              where users.Email == usuario && users.Password == password
                              select users;

                    if ( lst.Count() > 0)
                    {
                        users users = lst.First();

                        return Content("1");
                    }
                    else
                    {
                        return Content("Error");
                    }
                }
                
            }
            catch (Exception ex) {
                return Content("Ocurrio un error: ( " + ex.Message);
            }

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
    }
}