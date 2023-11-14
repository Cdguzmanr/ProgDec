using CG.ProgDec.BL;
using CG.ProgDec.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.Controllers
{
    public class AdvisorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Advisorss";
            return View(AdvisorManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = AdvisorManager.LoadById(id);
            ViewBag.Title = "Details for " + item.Name;
            return View(item);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create an Advisor";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Advisor advisor)
        {
            try
            {
                int result = AdvisorManager.Insert(advisor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create an Advisor";
                ViewBag.Error = ex.Message;
                return View(advisor);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = AdvisorManager.LoadById(id);
            ViewBag.Title = "Edit " + item.Name;
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int id, Advisor advisor, bool rollback = false)
        {
            try
            {
                int result = AdvisorManager.Update(advisor, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit " + advisor.Name;
                ViewBag.Error = ex.Message;
                return View(advisor);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = AdvisorManager.LoadById(id);
            ViewBag.Title = "Delete " + item.Name;
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, Advisor advisor, bool rollback = false)
        {
            try
            {
                int result = AdvisorManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete " + advisor.Name;
                ViewBag.Error = ex.Message;
                return View(advisor);
            }
        }


    }
}
