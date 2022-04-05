using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoMVC.Models;

namespace cursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModels> lst = null;

            using (cursoMVCEntities db = new cursoMVCEntities())
            {
                lst = (from d in db.users where d.IdState == 1 
                       orderby d.Email
                       select new UserTableViewModels
                       {
                           Email = d.Email,
                           id =d.id
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult InsertUser(UserViewModels obj)
        {
            using (var db = new cursoMVCEntities())
            {
                users Ousers = new users();

                Ousers.Email = obj.Email;
                //Ousers.IdState = 1;

                db.users.Add(Ousers);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/user/Index"));
        }

        public ActionResult Edit(int Id)
        {
            EditViewModels model = new EditViewModels();
            using (var db = new cursoMVCEntities())
            {
                var oUser = db.users.Find(Id);

                model.id = oUser.id;
                model.Email = oUser.Email;
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            using (var db = new cursoMVCEntities())
            {
                var oUser = db.users.Find(id);

                oUser.IdState = 3;
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }

    }
}