﻿using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Students";
            return View(StudentManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = StudentManager.LoadById(id);
            ViewBag.Title = "Details for " + item.FullName;
            return View(item);
        }

        public IActionResult Create()
        {

            ViewBag.Title = "Create a Student";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                int result = StudentManager.Insert(student);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create a Student";
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = StudentManager.LoadById(id);
            ViewBag.Title = "Edit " + item.FullName;
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student, bool rollback = false)
        {
            try
            {
                int result = StudentManager.Update(student, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Title = "Edit " + student.FullName;
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = StudentManager.LoadById(id);
            ViewBag.Title = "Delete " + item.FullName;
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, Student student, bool rollback = false)
        {
            try
            {
                int result = StudentManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }


    }
}
