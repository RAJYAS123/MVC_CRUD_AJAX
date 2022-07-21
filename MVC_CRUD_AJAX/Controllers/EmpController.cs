using MVC_CRUD_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_AJAX.Controllers
{
    public class EmpController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Emp
        public ActionResult Index()
        {
            var data = db.tblemployees.ToList();
            return View(data);
        }

        public JsonResult Create(tblemployee emp)
        {
            db.tblemployees.Add(emp);
            db.SaveChanges();
            return Json(emp);
        }

        public ActionResult Update(tblemployee emp)
        {

            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return new EmptyResult();
        }

        public ActionResult Delete(int id)
        {
            var data = db.tblemployees.Find(id);
            db.tblemployees.Remove(data);
            db.SaveChanges();
            return new EmptyResult();
        }
    }
}