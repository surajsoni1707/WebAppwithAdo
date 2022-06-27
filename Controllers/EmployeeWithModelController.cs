using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppwithAdo.Models;

namespace WebAppwithAdo.Controllers
{
    public class EmployeeWithModelController : Controller
    {
        EmployeeAdd emp = new EmployeeAdd();
        // GET: EmployeeWithModelController
        public ActionResult Index()
        {
            var model = emp.GetAllProducts();
            return View(model);
        }

        // GET: EmployeeWithModelController/Details/5
        public ActionResult Details(int id)
        {
            Employee e = emp.GetProductById(id);
            return View(e);
        }

        // GET: EmployeeWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee e)
        {
            try
            {
                emp.Save(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee e = emp.GetProductById(id);
            return View(e);
        }

        // POST: EmployeeWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee e)
        {
            try
            {
                emp.update(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e = emp.GetProductById(id);
            return View(e);
        }

        // POST: EmployeeWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCofirm(int id)
        {
            int res = emp.Delete(id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
