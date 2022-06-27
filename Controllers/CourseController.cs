using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppwithAdo.Models;

namespace WebAppwithAdo.Controllers
{
    public class CourseController : Controller
    {
        CourseDAL cd = new CourseDAL();
        public IActionResult List()
        {
            ViewBag.CourseList = cd.GetAllCourse();
            return View();
        }
        public IActionResult AddNewCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCourse(IFormCollection form)
        {
            Course c = new Course();
            c.Name = form["name"];
            c.Fees = Convert.ToSingle(form["Fees"]);
            int result = cd.Save(c);
            if (result == 1)
            {

                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course c = cd.GetCourseById(id);
            ViewBag.Id = c.Id;
            ViewBag.Name = c.Name;
            ViewBag.Fees = c.Fees;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Course c = new Course();
            c.Id = Convert.ToInt32(form["id"]);
            c.Name = form["Name"].ToString();
            c.Fees = Convert.ToSingle(form["Fees"]);
            int res = cd.Update(c);
            if (res == 1)
            {
                return RedirectToAction("List");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course c = cd.GetCourseById(id);
            ViewBag.Id = c.Id;
            ViewBag.Name = c.Name;
            ViewBag.Fees = c.Fees;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = cd.Delete(id);
            if (res == 1)
            {
                return RedirectToAction("List");
            }
            else
                return View();
        }
    }   
}
