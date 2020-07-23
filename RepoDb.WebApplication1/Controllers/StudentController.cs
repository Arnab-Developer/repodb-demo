using Microsoft.AspNetCore.Mvc;
using RepoDbDemo.WebApplication1.Dal;
using RepoDbDemo.WebApplication1.Models;
using System.Collections.Generic;

namespace RepoDbDemo.WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDal _studentDal;

        public StudentController(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public ActionResult Index()
        {
            IEnumerable<Student> students = _studentDal.GetAll();
            return View(students);
        }

        public ActionResult Details(int id)
        {
            Student student = _studentDal.GetById(id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentDal.Create(newStudent);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Student student = _studentDal.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student existingStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentDal.Update(existingStudent);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Student student = _studentDal.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student existingStudent)
        {
            try
            {
                _studentDal.Delete(existingStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
