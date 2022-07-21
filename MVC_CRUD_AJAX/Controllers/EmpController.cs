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
            int  a=  db.SaveChanges();
            if (a == 1)
            {
                TempData["messege"] = "Data Has Been Inserted";
                ModelState.Clear();               
            }
            return Json(emp);
        }

        public ActionResult Update(tblemployee emp)
        {

            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            int a= db.SaveChanges();
            if (a == 1)
            {
                TempData["messegeUpdate"] = "Data Has Been Updated";                        
            }
            return new EmptyResult();
        }

        public ActionResult Delete(int id)
        {
            var data = db.tblemployees.Find(id);
            db.tblemployees.Remove(data);
            int a =  db.SaveChanges();
            if (a == 1)
            {
                TempData["messegeDelete"] = "Data Has Been Deleted";
            }
            return new EmptyResult();
        }
    }
}