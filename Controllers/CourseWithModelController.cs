using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppwithAdo.Models;

namespace WebAppwithAdo.Controllers
{
    public class CourseWithModelController : Controller
    {
        CourseDAL cd = new CourseDAL(); 
        // GET: CourseWithModelController
        public ActionResult Index()
        {
            var model = cd.GetAllCourse();
            return View(model);
        }

        // GET: CourseWithModelController/Details/5
        public ActionResult Details(int id)
        {
            Course c = cd.GetCourseById(id);
            return View(c);
        }

        // GET: CourseWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course c)
        {
            cd.Save(c);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Course c = cd.GetCourseById(id);
            return View(c);
        }

        // POST: CourseWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course c)
        {
            
            try
            {
                cd.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Course c = cd.GetCourseById(id);
            return View(c);
        }

        // POST: CourseWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = cd.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
