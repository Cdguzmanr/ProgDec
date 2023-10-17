﻿using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class DegreeTypeController : Controller
    {
        public IActionResult Index()
        {
            return View(DegreeTypeManager.Load());
        }

        public IActionResult Details(int id)
        {
            return View(DegreeTypeManager.LoadById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DegreeType degreeType)
        {
            try
            {
                int result = DegreeTypeManager.Insert(degreeType);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(DegreeTypeManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, DegreeType degreeType, bool rollback = false)
        {
            try
            {
                int result = DegreeTypeManager.Update(degreeType, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(degreeType);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(DegreeTypeManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, DegreeType degreeType, bool rollback = false)
        {
            try
            {
                int result = DegreeTypeManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(degreeType);
            }
        }


    }
}