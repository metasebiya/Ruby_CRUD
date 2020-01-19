using CrudDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWeb.Controllers
{
    public class EmpCrudController : Controller
    {
        CrudDbDataContext context = new CrudDbDataContext();
        // GET: EmpCrud
        public ActionResult Index()
        {
            var empdetails = from x in context.EmpTables select x;
            return View(empdetails);
        }

        // GET: EmpCrud/Details/5
        public ActionResult Details(int id)
        {
            var getempdetails = context.EmpTables.Single(x => x.EmpId == id);
            return View(getempdetails);
        }

        // GET: EmpCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpCrud/Create
        [HttpPost]
        public ActionResult Create(EmpTable collection)
        {
            try
            {
                // TODO: Add insert logic here
                context.EmpTables.InsertOnSubmit(collection);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCrud/Edit/5
        public ActionResult Edit(int id)
        {
            var getempdetails = context.EmpTables.Single(x => x.EmpId == id);
            return View(getempdetails);
        }

        // POST: EmpCrud/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmpTable collection)
        {
            try
            {
                // TODO: Add update logic here
                EmpTable empupdate = context.EmpTables.Single(x => x.EmpId == id);
                empupdate.EmpName = collection.EmpName;
                empupdate.Email = collection.Email;
                empupdate.Salary = collection.Salary;
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCrud/Delete/5
        public ActionResult Delete(int id)
        {
            var getempdetails = context.EmpTables.Single(x => x.EmpId == id);
            return View(getempdetails);
        }

        // POST: EmpCrud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmpTable collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdel = context.EmpTables.Single(x => x.EmpId == id);
                context.EmpTables.DeleteOnSubmit(collection);
                context.SubmitChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
