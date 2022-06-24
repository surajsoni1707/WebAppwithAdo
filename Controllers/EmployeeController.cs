using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppwithAdo.Models;

namespace WebAppwithAdo.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeAdd emp = new EmployeeAdd();

        public IActionResult List()
        {
            ViewBag.EmployeeList = emp.GetAllProducts();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Employee p = new Employee();
            p.Name = form["Name"];
            p.Salary = Convert.ToSingle(form["salary"]);
            int res = emp.Save(p);
            if (res == 1)
            {

                return RedirectToAction("List");

            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Employee prod = emp.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Salary = prod.Salary;
            ViewBag.Id = prod.Id;
            return View();

        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Employee prod = new Employee();
            prod.Name = form["Name"];
            prod.Salary = Convert.ToSingle(form["salary"]);
            prod.Id = Convert.ToInt32(form["id"]);
            int res = emp.update(prod);
            if (res == 1)
            {
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee prod = emp.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Salary = prod.Salary;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = emp.Delete(id);
            if (res == 1)
            {
                return RedirectToAction("List");

            }
            return View();
        }
    }
}
